using System;
using Microsoft.Extensions.Logging;
using Moq;
using ProductApi.Models.Dtos;
using ProductApi.Repositories;
using ProductApi.Repositories.Interfaces;
using ProductApi.Services.Implementation;
using ProductApi.Services.Interfaces;
using Xunit;

namespace ProductApi.Tests.Services
{
    public class ProductOptionServices_Tests
    {
        private readonly Guid _optionId1 = Guid.NewGuid();
        private readonly Guid _optionId2 = Guid.NewGuid();
        private readonly Guid _optionId3 = Guid.NewGuid();
        private readonly Mock<IProductOptionRepository> _poRepo;

        private readonly Guid _productId1 = Guid.NewGuid();
        private readonly Guid _productId2 = Guid.NewGuid();
        private readonly IProductOptionService _service;

        public ProductOptionServices_Tests()
        {
            var pRepo = new Mock<IProductRepository>();
            _poRepo = new Mock<IProductOptionRepository>();
            var logger = new Mock<ILogger<ProductOptionService>>();

            pRepo.Setup(p => p.GetProductById(_productId1))
                .ReturnsAsync(new ProductDto
                {
                    Id = _productId1,
                    Name = "active product"
                });
            pRepo.Setup(p => p.GetProductById(_productId2))
                .ReturnsAsync((ProductDto) null);

            _poRepo.Setup(po => po.GetProductOptionById(_optionId1)).ReturnsAsync(new ProductOptionDto
            {
                Id = _optionId1,
                ProductId = _productId1,
                Name = "option 1 of product 1"
            });
            _poRepo.Setup(po => po.GetProductOptionById(_optionId2))
                .ReturnsAsync((ProductOptionDto) null);

            _service = new ProductOptionService(pRepo.Object, _poRepo.Object, logger.Object);
        }

        #region UpdateProduct

        [Fact(DisplayName = "Update Product, success, should not throw exception.")]
        public async void Update_Test1()
        {
            var target = new ProductOptionDto
            {
                Id = _optionId1,
                ProductId = _productId1
            };
            _poRepo.Setup(po => po.UpdateProductOption(It.IsAny<ProductOptionDto>()))
                .ReturnsAsync((ProductOptionDto input) => input);

            var exception = await Record.ExceptionAsync(async () => { await _service.UpdateProductOption(target); });

            Assert.Null(exception);
        }

        [Fact(DisplayName = "Update Product, option not found, should throw exception")]
        public async void Update_Test2()
        {
            var target = new ProductOptionDto
            {
                Id = _optionId2,
                ProductId = _productId1
            };
            _poRepo.Setup(po => po.UpdateProductOption(It.IsAny<ProductOptionDto>()))
                .ReturnsAsync((ProductOptionDto input) => input);

            var exception = await Record.ExceptionAsync(async () => { await _service.UpdateProductOption(target); });
            Assert.NotNull(exception);
            Assert.Equal($"Can not find product option {target.Id} under product {target.ProductId}.",
                exception.Message);
        }

        [Fact(DisplayName = "Update Product, product not found, should throw exception")]
        public async void Update_Test3()
        {
            var target = new ProductOptionDto
            {
                Id = _optionId3,
                ProductId = _productId2
            };
            _poRepo.Setup(po => po.UpdateProductOption(It.IsAny<ProductOptionDto>()))
                .ReturnsAsync((ProductOptionDto input) => input);

            var exception = await Record.ExceptionAsync(async () => { await _service.UpdateProductOption(target); });
            Assert.NotNull(exception);
            Assert.Equal($"Can not find product with id {target.ProductId}.", exception.Message);
        }

        [Fact(DisplayName = "Update Product, Invalid product id, should throw exception")]
        public async void Update_Test4()
        {
            var target = new ProductOptionDto
            {
                Id = Guid.Empty,
                ProductId = _productId1
            };

            var exception = await Record.ExceptionAsync(async () => { await _service.UpdateProductOption(target); });

            Assert.NotNull(exception);
            Assert.Equal("Product option Id can not be empty.", exception.Message);
        }

        #endregion
    }
}