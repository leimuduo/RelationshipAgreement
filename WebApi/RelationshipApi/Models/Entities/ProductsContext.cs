using Microsoft.EntityFrameworkCore;

namespace RelationshipApi.Models.Entities
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            // modelBuilder.Entity<Product>()
            //     .HasMany(p => p.ProductOptions)
            //     .WithOne(po => po.Product)
            //     .HasForeignKey("FK_ProductOptionProduct");

            modelBuilder.Entity<ProductOption>()
                .HasKey(po => po.Id);

            modelBuilder.Entity<ProductOption>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOptions)
                .HasForeignKey(po => po.ProductId)
                .HasConstraintName("FK_ProductOption_Product")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}