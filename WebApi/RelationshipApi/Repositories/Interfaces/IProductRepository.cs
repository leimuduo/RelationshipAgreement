using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;

namespace RelationshipApi.Repositories
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProductById(Guid productId);
        Task<List<ProductDto>> GetAllProducts();
        Task<List<ProductDto>> GetProductsByName(string name);
        Task<ProductDto> CreateProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(Guid id);
    }
}