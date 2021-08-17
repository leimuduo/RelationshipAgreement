using System;
using System.Collections.Generic;
using ProductApi.Helpers;
using ProductApi.Models.Entities;

namespace ProductsApi.Integration.Tests
{
    public class Utilities
    {
        public static void InitializeDbForTests(ProductsContext db)
        {
            var product1Id = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0938a");
            var product2Id = Guid.NewGuid();
            var product3Id = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0938b");

            var products = new List<Product>
            {
                new()
                {
                    Id = product1Id,
                    Name = "test1",
                    Description = "test1 description",
                    Price = 10.99M,
                    DeliveryPrice = 6.99M,
                    Status = (int) ProductStatusEnum.Active
                },
                new()
                {
                    Id = product2Id,
                    Name = "test2",
                    Description = "test2 description",
                    Price = 12.99M,
                    DeliveryPrice = 7.99M,
                    Status = (int) ProductStatusEnum.Active
                },
                new()
                {
                    Id = product3Id,
                    Name = "test3",
                    Description = "test3 for deleting test.",
                    Price = 12.99M,
                    DeliveryPrice = 7.99M,
                    Status = (int) ProductStatusEnum.Active
                }
            };

            var productOptions = new List<ProductOption>
            {
                new()
                {
                    Id = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0456b"),
                    ProductId = product1Id,
                    Name = "Colour",
                    Description = "White"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = product1Id,
                    Name = "Colour",
                    Description = "Black"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = product2Id,
                    Name = "Size",
                    Description = "Small"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = product2Id,
                    Name = "Colour",
                    Description = "Large"
                },
                new()
                {
                    Id = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0938c"),
                    ProductId = product2Id,
                    Name = "Colour",
                    Description = " to delete"
                }
            };
            db.Products.AddRange(products);
            db.ProductOptions.AddRange(productOptions);
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ProductsContext db)
        {
            db.ProductOptions.RemoveRange(db.ProductOptions);
            db.Products.RemoveRange(db.Products);
            InitializeDbForTests(db);
        }
    }
}