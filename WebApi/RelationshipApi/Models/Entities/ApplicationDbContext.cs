using Microsoft.EntityFrameworkCore;

namespace RelationshipApi.Models.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Member>()
                .HasKey(m => m.UserId);
            modelBuilder.Entity<Family>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Token>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<User>()
                .HasOne(m => m.Member)
                .WithOne(m => m.UserDto)
                .HasForeignKey<Member>(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Member>()
                .HasOne(f => f.Family)
                .WithMany(f => f.Members)
                .HasConstraintName("FK_Member_Family")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Token>()
                .HasOne(t => t.Member)
                .WithMany(m => m.Tokens)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Invitation>()
                .HasOne(i => i.Invitor)
                .WithMany(m => m.Invitations)
                .HasConstraintName("FK_Invitation_Member")
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Invitation>()
                .HasOne(i => i.Family)
                .WithMany(f => f.Invitations)
                .HasConstraintName("FK_Invitation_Family")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}