using System;
using Microsoft.Extensions.Logging;
using Moq;
using ProductApi.Models.Dtos;
using ProductApi.Repositories;
using ProductApi.Services.Implementation;
using ProductApi.Services.Interfaces;
using Xunit;

namespace ProductApi.Tests.Services
{
    public class ProductServices_Tests
    {
        private readonly Mock<ICacheService> _cache;
        private readonly Mock<ILogger<ProductService>> _logger;
        private readonly Guid _productId2 = Guid.NewGuid();
        private readonly Guid _productId3 = Guid.NewGuid();

        private readonly Mock<IProductRepository> _repo;
        private readonly IProductService _service;

        public ProductServices_Tests()
        {
            _repo = new Mock<IProductRepository>();
            _logger = new Mock<ILogger<ProductService>>();
            _cache = new Mock<ICacheService>();


            _service = new ProductService(_repo.Object, _logger.Object, _cache.Object);
        }

        #region UpdateProduct

        [Fact(DisplayName = "Update Product, success, should not throw exception.")]
        public async void Update_Test1()
        {
            var target = new ProductDto
            {
                Id = _productId2,
                Name = "Product Update",
                Price = 19.99m,
                DeliveryPrice = 1.12m,
                Description = "New product for test. Updated"
            };

            _repo.Setup(r => r.GetProductById(_productId2)).ReturnsAsync(target);
            _repo.Setup(r => r.UpdateProduct(It.IsAny<ProductDto>()))
                .ReturnsAsync((ProductDto input) => input);


            var exception = await Record.ExceptionAsync(async () =>
            {
                var result = await _service.UpdateProduct(target);
            });

            Assert.Null(exception);
        }

        [Fact(DisplayName = "Update Product, product not found, should throw exception")]
        public async void Update_Test2()
        {
            var target = new ProductDto
            {
                Id = _productId2,
                Name = "Product Update",
                Price = 19.99m,
                DeliveryPrice = 1.12m,
                Description = "New product for test. Updated"
            };

            _repo.Setup(r => r.GetProductById(_productId2)).ReturnsAsync((ProductDto) null);

            var exception = await Record.ExceptionAsync(async () => { await _service.UpdateProduct(target); });

            Assert.NotNull(exception);
            Assert.Equal($"Can not find product with id {target.Id}.", exception.Message);
        }

        [Fact(DisplayName = "Update Product, Invalid product id, should throw exception")]
        public async void Update_Test3()
        {
            var target = new ProductDto
            {
                Id = Guid.Empty,
                Name = "Product Update",
                Price = 19.99m,
                DeliveryPrice = 1.12m,
                Description = "New product for test. Updated"
            };

            var exception = await Record.ExceptionAsync(async () => { await _service.UpdateProduct(target); });

            Assert.NotNull(exception);
            Assert.Equal("Product Id can not be empty.", exception.Message);
        }

        #endregion

        #region DeleteProduct

        [Fact(DisplayName = "Delete Product, success, should not throw exception.")]
        public async void Delete_Test1()
        {
            _repo.Setup(r => r.GetProductById(_productId3)).ReturnsAsync(new ProductDto {Id = _productId3});
            _repo.Setup(r => r.DeleteProduct(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var exception = await Record.ExceptionAsync(async () => { await _service.DeleteProduct(_productId3); });

            Assert.Null(exception);
        }

        [Fact(DisplayName = "Delete Product, product not found, should throw exception")]
        public async void Delete_Test2()
        {
            _repo.Setup(r => r.GetProductById(_productId3)).ReturnsAsync((ProductDto) null);

            var exception = await Record.ExceptionAsync(async () => { await _service.DeleteProduct(_productId3); });

            Assert.NotNull(exception);
            Assert.Equal($"Can not find product with id {_productId3}.", exception.Message);
        }

        [Fact(DisplayName = "Update Product, Invalid product id, should throw exception")]
        public async void Delete_Test3()
        {
            var exception = await Record.ExceptionAsync(async () => { await _service.DeleteProduct(Guid.Empty); });

            Assert.NotNull(exception);
            Assert.Equal("Product Id can not be empty.", exception.Message);
        }

        #endregion
    }
}