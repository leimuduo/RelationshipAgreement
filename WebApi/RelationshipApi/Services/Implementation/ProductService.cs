using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RelationshipApi.Helpers.CustomiseExceptions;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Repositories;
using RelationshipApi.Repositories.Interfaces;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Services.Implementation
{
    public class ProductService
    {
        // private readonly ICacheService _cache;
        // private readonly ILogger<ProductService> _logger;
        // private readonly IProductRepository _repo;
        //
        // public ProductService(IProductRepository repo, ILogger<ProductService> logger, ICacheService cache)
        // {
        //     _repo = repo;
        //     _logger = logger;
        //     _cache = cache;
        // }
        //
        // public async Task<ProductDto> GetProductById(Guid productId)
        // {
        //     var cachedValue = _cache.TryGetValue<ProductDto>($"product_{productId}");
        //     if (cachedValue != null)
        //     {
        //         // about structured logging msg vs basic logging msg, please refer to here
        //         // https://stackoverflow.com/questions/65874828/message-template-should-be-compile-time-constant/65938575#65938575
        //         _logger.LogInformation("Product {ProductId} is reading from cache", productId);
        //         return cachedValue;
        //     }
        //
        //     var result = await _repo.GetProductById(productId);
        //     _cache.SetCacheValue($"product_{productId}", result);
        //     return result;
        // }
        //
        // public async Task<List<ProductDto>> GetAllProducts()
        // {
        //     return await _repo.GetAllProducts();
        // }
        //
        // public async Task<List<ProductDto>> GetProductsByName(string name)
        // {
        //     return await _repo.GetProductsByName(name);
        // }
        //
        // public async Task<ProductDto> CreateProduct(ProductDto product)
        // {
        //     var newProduct = await _repo.CreateProduct(product);
        //     _cache.SetCacheValue($"product_{newProduct.Id}", newProduct);
        //     return newProduct;
        // }
        //
        // public async Task<ProductDto> UpdateProduct(ProductDto product)
        // {
        //     await ValidateProductId(product.Id);
        //
        //     var updatedProduct = await _repo.UpdateProduct(product);
        //     _cache.SetCacheValue($"product_{updatedProduct.Id}", updatedProduct);
        //     return updatedProduct;
        // }
        //
        // public async Task DeleteProduct(Guid id)
        // {
        //     await ValidateProductId(id);
        //     _cache.RemoveValue<ProductDto>($"product_{id}");
        //     await _repo.DeleteProduct(id);
        // }
        //
        // private async Task ValidateProductId(Guid productId)
        // {
        //     if (productId == Guid.Empty)
        //     {
        //         // TODO: move the logging into resource file.
        //         _logger.LogError("Product Id can not be empty");
        //         throw new ProductApiValidationException("Product Id can not be empty.");
        //     }
        //
        //     var product = await _repo.GetProductById(productId);
        //
        //     if (product == null)
        //     {
        //         _logger.LogError("Can not find product with id {ProductId}", productId);
        //         throw new ProductApiValidationException($"Can not find product with id {productId}.");
        //     }
        // }
    }
}