using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProductApi.Helpers.Mapper;
using ProductApi.Models.Dtos;
using ProductApi.Models.Entities;
using ProductApi.Repositories.Implementation;
using ProductApi.Repositories.Interfaces;
using Xunit;

namespace ProductApi.Tests.Repositories
{
    public class ProductOptionRepository_Tests
    {
        private readonly ProductsContext _context;
        private readonly Guid _optionId1 = Guid.NewGuid();
        private readonly Guid _optionId2 = Guid.NewGuid();
        private readonly Guid _optionId3 = Guid.NewGuid();
        private readonly Guid _productId1 = Guid.NewGuid();
        private readonly Guid _productId2 = Guid.NewGuid();
        private readonly Guid _productId3 = Guid.NewGuid();

        private readonly IProductOptionRepository _repo;

        public ProductOptionRepository_Tests()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new ProductProfile()); });
            var mapper = mappingConfig.CreateMapper();
            var logger = new Mock<ILogger<ProductOptionRepository>>();

            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);
            var product1Option1 = new ProductOption
            {
                Id = _optionId1,
                Name = "option 1 for product 1",
                Description = "option for update test",
                ProductId = _productId1
            };

            var product1Option2 = new ProductOption
            {
                Id = _optionId2,
                Name = "option 2 for product 1",
                Description = "option for get test",
                ProductId = _productId1
            };

            var product2Option1 = new ProductOption
            {
                Id = _optionId3,
                Name = "option 3 for product 2",
                Description = "option for delete test",
                ProductId = _productId2
            };
            _context.ProductOptions.Add(product1Option1);
            _context.ProductOptions.Add(product1Option2);
            _context.ProductOptions.Add(product2Option1);
            _context.SaveChanges();
            _repo = new ProductOptionRepository(_context, mapper, logger.Object);
        }

        #region CreateProductOption

        [Fact(DisplayName = "Create Product Option")]
        public async void Create_Test1()
        {
            var newOption = new ProductOptionDto
            {
                Name = "newProductoption",
                Description = "new product option for product 3",
                ProductId = _productId3
            };

            var result = await _repo.CreateProductOption(newOption);

            var verifyResult = await _context.ProductOptions.FirstOrDefaultAsync(p => p.Id == result.Id);
            Assert.NotNull(result);
            Assert.NotNull(verifyResult);
            Assert.Equal(result.Name, verifyResult.Name);
            Assert.Equal(result.Description, verifyResult.Description);
            Assert.Equal(result.ProductId, verifyResult.ProductId);
        }

        #endregion

        #region GetProductOptionTest

        [Fact(DisplayName = "GetProductOptionById no data match")]
        public async void GetProductOption_Test1()
        {
            var result = await _repo.GetProductOptionById(Guid.NewGuid());
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetProductOptionById with data match")]
        public async void GetProductOption_Test2()
        {
            var result = await _repo.GetProductOptionById(_optionId2);

            Assert.NotNull(result);
            Assert.Equal("option for get test", result.Description);
        }

        [Fact(DisplayName = "GetAllProductOptionsByProductId data match")]
        public async void GetProductOption_Test3()
        {
            var result = await _repo.GetAllProductOptionsByProductId(_productId1);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("option for update test", result[0].Description);
            Assert.Equal("option for get test", result[1].Description);
        }

        [Fact(DisplayName = "GetAllProductOptionsByProductId no data match")]
        public async void GetProductOption_Test4()
        {
            var result = await _repo.GetAllProductOptionsByProductId(Guid.NewGuid());
            Assert.NotNull(result);
        }

        #endregion GetProductById

        #region UpdateProductOption

        [Fact(DisplayName = "Update Product Option")]
        public async void Update_Test1()
        {
            var target = new ProductOptionDto
            {
                Id = _optionId1,
                Name = "Product Option updated",
                Description = "This product option has been updated."
            };

            var result = await _repo.UpdateProductOption(target);

            var verifyResult = await _context.ProductOptions.FirstOrDefaultAsync(p => p.Id == _optionId1);
            Assert.NotNull(result);
            Assert.NotNull(verifyResult);
            Assert.Equal(verifyResult.Name, verifyResult.Name);
            Assert.Equal(verifyResult.Description, verifyResult.Description);
        }

        [Fact(DisplayName = "Update Product - Product option not found")]
        public async void Update_Test2()
        {
            var target = new ProductOptionDto
            {
                Id = Guid.NewGuid(),
                Name = "Product Option Update",
                Description = "Fake product option that doesn't exist"
            };

            var exception = await Record.ExceptionAsync(async () =>
            {
                var result = await _repo.UpdateProductOption(target);
            });

            Assert.NotNull(exception);
            Assert.Equal($"Fail to update product option {target.Id}.", exception.Message);
            Assert.Equal($"Can not find product option {target.Id} during update.", exception.InnerException?.Message);
        }

        #endregion

        #region Delete Product Option

        [Fact(DisplayName = "Delete Product")]
        public async void Delete_Test1()
        {
            var exception = await Record.ExceptionAsync(async () => { await _repo.DeleteProductOption(_optionId3); });

            Assert.Null(exception);

            var verifyResult = await _context.ProductOptions.FirstOrDefaultAsync(p => p.Id == _optionId3);
            Assert.Null(verifyResult);
        }

        [Fact(DisplayName = "Delete Product - product can't find")]
        public async void Delete_Test2()
        {
            var fakeGuid = Guid.NewGuid();
            var exception = await Record.ExceptionAsync(async () => { await _repo.DeleteProductOption(fakeGuid); });

            Assert.NotNull(exception);
            Assert.Equal($"Fail to remove product option {fakeGuid}.", exception.Message);
            Assert.Equal($"Can not find product option {fakeGuid} during deleting.",
                exception.InnerException?.Message);
        }

        #endregion endregion
    }
}