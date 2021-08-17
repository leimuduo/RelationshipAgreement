using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProductApi.Helpers;
using ProductApi.Helpers.Mapper;
using ProductApi.Models.Dtos;
using ProductApi.Models.Entities;
using ProductApi.Repositories;
using ProductApi.Repositories.Implementation;
using Xunit;

namespace ProductApi.Tests.Repositories
{
    public class ProductRepository_Tests
    {
        private readonly Mock<ILogger<ProductRepository>> _logger;
        private readonly IMapper _mapper;
        private ProductsContext _context;
        private IProductRepository _repo;

        public ProductRepository_Tests()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new ProductProfile()); });
            _mapper = mappingConfig.CreateMapper();
            _logger = new Mock<ILogger<ProductRepository>>();
        }

        #region Create Product

        [Fact(DisplayName = "Create Product")]
        public async void Create_Test1()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            var newProduct = new ProductDto
            {
                Name = "NewProduct0",
                Price = 9.99m,
                DeliveryPrice = 0.12m,
                Description = "New product for test."
            };

            _repo = new ProductRepository(_context, _mapper, _logger.Object);

            var result = await _repo.CreateProduct(newProduct);

            var verifyResult = await _context.Products.FirstOrDefaultAsync(p => p.Id == result.Id);
            Assert.NotNull(result);
            Assert.NotNull(verifyResult);
            Assert.Equal(result.Name, verifyResult.Name);
            Assert.Equal(result.DeliveryPrice, verifyResult.DeliveryPrice);
            Assert.Equal(result.Price, verifyResult.Price);
            Assert.Equal(result.Description, verifyResult.Description);
        }

        #endregion endregion

        #region Get Product

        [Fact(DisplayName = "GetProductById no data match")]
        public async void GetProduct_Test1()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);

            var result = await _repo.GetProductById(Guid.NewGuid());
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetProductById with data match")]
        public async void GetProduct_Test2()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);
            var activeProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "active product for update",
                Price = 1.99m,
                DeliveryPrice = 0.3m,
                Description = "product for update test.",
                Status = (int) ProductStatusEnum.Active
            };
            await _context.Products.AddAsync(activeProduct);
            await _context.SaveChangesAsync();

            var result = await _repo.GetProductById(activeProduct.Id);
            Assert.NotNull(result);
            Assert.Equal(activeProduct.Id, result.Id);
        }

        [Fact(DisplayName = "GetProductById data match but not active")]
        public async void GetProduct_Test3()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);
            var inactiveProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Inactive product for update",
                Price = 1.99m,
                DeliveryPrice = 0.3m,
                Description = "product for update test.",
                Status = (int) ProductStatusEnum.Inactive
            };
            await _context.Products.AddAsync(inactiveProduct);
            await _context.SaveChangesAsync();
            _repo = new ProductRepository(_context, _mapper, _logger.Object);

            var result = await _repo.GetProductById(inactiveProduct.Id);
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetAllProducts with valid data")]
        public async void GetProduct_Test4()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);
            var activeProduct1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "active product for update",
                Price = 1.99m,
                DeliveryPrice = 0.3m,
                Description = "product for update test.",
                Status = (int) ProductStatusEnum.Active
            };
            var activeProduct2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "active product for update",
                Price = 1.99m,
                DeliveryPrice = 0.3m,
                Description = "product for update test.",
                Status = (int) ProductStatusEnum.Active
            };
            await _context.Products.AddAsync(activeProduct1);
            await _context.Products.AddAsync(activeProduct2);
            await _context.SaveChangesAsync();

            var result = await _repo.GetAllProducts();
            var target = _context.Products.Count(p => p.Status == (int) ProductStatusEnum.Active);
            Assert.NotNull(result);
            Assert.Equal(target, result.Count);
        }

        [Fact(DisplayName = "GetProductByName with valid data")]
        public async void GetProduct_Test5()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);
            var activeProduct1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "active product for update",
                Price = 1.99m,
                DeliveryPrice = 0.3m,
                Description = "product for update test.",
                Status = (int) ProductStatusEnum.Active
            };
            await _context.Products.AddAsync(activeProduct1);
            await _context.SaveChangesAsync();

            var result = await _repo.GetProductsByName(activeProduct1.Name);
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact(DisplayName = "GetProductByName with no valid data")]
        public async void GetProduct_Test6()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);

            var result = await _repo.GetProductsByName("Stupid name with no product matches");
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        #endregion Get Product

        #region UpdateProduct

        [Fact(DisplayName = "Update Product")]
        public async void Update_Test1()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);
            var activeProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "active product for update",
                Price = 1.99m,
                DeliveryPrice = 0.3m,
                Description = "product for update test.",
                Status = (int) ProductStatusEnum.Active
            };
            await _context.Products.AddAsync(activeProduct);
            await _context.SaveChangesAsync();

            var target = new ProductDto
            {
                Id = activeProduct.Id,
                Name = "Product Update",
                Price = 19.99m,
                DeliveryPrice = 1.12m,
                Description = "New product for test. Updated"
            };

            var result = await _repo.UpdateProduct(target);

            var verifyResult = await _context.Products.FirstOrDefaultAsync(p => p.Id == activeProduct.Id);
            Assert.NotNull(result);
            Assert.NotNull(verifyResult);
            Assert.Equal(verifyResult.Name, verifyResult.Name);
            Assert.Equal(verifyResult.Price, verifyResult.Price);
            Assert.Equal(verifyResult.DeliveryPrice, verifyResult.DeliveryPrice);
        }

        [Fact(DisplayName = "Update Product - Product not found")]
        public async void Update_Test2()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);

            var target = new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = "Product Update",
                Price = 19.99m,
                DeliveryPrice = 1.12m,
                Description = "New product for test. Updated"
            };

            var exception = await Record.ExceptionAsync(async () =>
            {
                var result = await _repo.UpdateProduct(target);
            });

            Assert.NotNull(exception);
            Assert.Equal($"Fail to update product {target.Id}.", exception.Message);
            Assert.Equal($"Can not find product {target.Id} during update.", exception.InnerException?.Message);
        }

        [Fact(DisplayName = "Update Product - Product not active")]
        public async void Update_Test3()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);
            var inActiveProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "inactive product for update",
                Price = 1.99m,
                DeliveryPrice = 0.3m,
                Description = "product for update test.",
                Status = (int) ProductStatusEnum.Inactive
            };
            await _context.Products.AddAsync(inActiveProduct);
            await _context.SaveChangesAsync();

            var target = new ProductDto
            {
                Id = inActiveProduct.Id,
                Name = "Product Update",
                Price = 19.99m,
                DeliveryPrice = 1.12m,
                Description = "New product for test. Updated"
            };

            var exception = await Record.ExceptionAsync(async () =>
            {
                var result = await _repo.UpdateProduct(target);
            });

            Assert.NotNull(exception);
            Assert.Equal($"Fail to update product {target.Id}.", exception.Message);
            Assert.Equal($"Can not update product {target.Id} due to it's inactive.",
                exception.InnerException?.Message);
        }

        #endregion

        #region Delete Product

        [Fact(DisplayName = "Delete Product")]
        public async void Delete_Test1()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);
            var productForDelete = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product for delete test",
                Price = 19.99m,
                DeliveryPrice = 1.12m,
                Description = "New product for test. Delete",
                Status = (int) ProductStatusEnum.Active
            };
            await _context.Products.AddAsync(productForDelete);
            await _context.SaveChangesAsync();

            var exception = await Record.ExceptionAsync(async () =>
            {
                await _repo.DeleteProduct(productForDelete.Id);
            });

            Assert.Null(exception);

            var verifyResult = await _context.Products.FirstOrDefaultAsync(p => p.Id == productForDelete.Id);
            Assert.NotNull(verifyResult);
            Assert.Equal((int) ProductStatusEnum.Inactive, verifyResult.Status);
        }

        [Fact(DisplayName = "Delete Product - product can't find")]
        public async void Delete_Test2()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>()
                .UseInMemoryDatabase("ImMemoryDB")
                .Options;
            _context = new ProductsContext(options);

            _repo = new ProductRepository(_context, _mapper, _logger.Object);

            var fakeGuid = Guid.NewGuid();
            var exception = await Record.ExceptionAsync(async () => { await _repo.DeleteProduct(fakeGuid); });

            Assert.NotNull(exception);
            Assert.Equal($"Fail to remove product {fakeGuid}.", exception.Message);
            Assert.Equal($"Can not find product {fakeGuid} during deleting.",
                exception.InnerException?.Message);
        }

        #endregion endregion
    }
}