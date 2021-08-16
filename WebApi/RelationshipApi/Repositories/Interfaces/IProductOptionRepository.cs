using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;

namespace RelationshipApi.Repositories.Interfaces
{
    public interface IProductOptionRepository
    {
        Task<ProductOptionDto> GetProductOptionById(Guid id);
        Task<List<ProductOptionDto>> GetAllProductOptionsByProductId(Guid productId);
        Task<ProductOptionDto> CreateProductOption(ProductOptionDto option);
        Task<ProductOptionDto> UpdateProductOption(ProductOptionDto option);
        Task<bool> DeleteProductOption(Guid id);
    }
}