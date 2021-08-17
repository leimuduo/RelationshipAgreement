using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RelationshipApi.Helpers.CustomiseExceptions;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Models.Entities;
using RelationshipApi.Repositories.Interfaces;

namespace RelationshipApi.Repositories.Implementation
{
    public class ProductOptionRepository : IProductOptionRepository
    {
    //     private readonly ProductsContext _context;
    //     private readonly ILogger<ProductOptionRepository> _logger;
    //     private readonly IMapper _mapper;
    //
    //     public ProductOptionRepository(
    //         ProductsContext context,
    //         IMapper mapper,
    //         ILogger<ProductOptionRepository> logger)
    //     {
    //         _context = context;
    //         _logger = logger;
    //         _mapper = mapper;
    //     }
    //
    //     public async Task<ProductOptionDto> GetProductOptionById(Guid id)
    //     {
    //         var option = await _context.ProductOptions.FirstOrDefaultAsync(po => po.Id == id);
    //
    //         return _mapper.Map<ProductOption, ProductOptionDto>(option);
    //     }
    //
    //     public async Task<List<ProductOptionDto>> GetAllProductOptionsByProductId(Guid productId)
    //     {
    //         var options = await _context.ProductOptions.Where(po => po.ProductId == productId).ToListAsync();
    //
    //         return _mapper.Map<List<ProductOption>, List<ProductOptionDto>>(options);
    //     }
    //
    //     public async Task<ProductOptionDto> CreateProductOption(ProductOptionDto option)
    //     {
    //         var entity = _mapper.Map<ProductOptionDto, ProductOption>(option);
    //
    //         try
    //         {
    //             var newCreatedProductOption = await _context.ProductOptions.AddAsync(entity);
    //             await _context.SaveChangesAsync();
    //             return _mapper.Map<ProductOption, ProductOptionDto>(newCreatedProductOption.Entity);
    //         }
    //         catch (Exception e)
    //         {
    //             HandleLogging(LogLevel.Error, "Fail to create product option.", e);
    //         }
    //
    //         return null;
    //     }
    //
    //     public async Task<ProductOptionDto> UpdateProductOption(ProductOptionDto option)
    //     {
    //         try
    //         {
    //             var source = await _context.ProductOptions.FirstOrDefaultAsync(po => po.Id == option.Id);
    //             if (source == null) throw new Exception($"Can not find product option {option.Id} during update.");
    //
    //             source.Name = option.Name;
    //             source.Description = option.Description;
    //             // _context.Update(source);
    //             await _context.SaveChangesAsync();
    //
    //             return _mapper.Map<ProductOption, ProductOptionDto>(source);
    //         }
    //         catch (Exception e)
    //         {
    //             HandleLogging(LogLevel.Error, $"Fail to update product option {option.Id}.", e);
    //         }
    //
    //         return option;
    //     }
    //
    //     public async Task<bool> DeleteProductOption(Guid id)
    //     {
    //         try
    //         {
    //             var source = await _context.ProductOptions.FirstOrDefaultAsync(po => po.Id == id);
    //             if (source == null)
    //                 HandleLogging(LogLevel.Error, $"Can not find product option {id} during deleting.", null);
    //
    //             _context.ProductOptions.Remove(source);
    //             await _context.SaveChangesAsync();
    //             return true;
    //         }
    //         catch (Exception e)
    //         {
    //             HandleLogging(LogLevel.Error, $"Fail to remove product option {id}.", e);
    //         }
    //
    //         return false;
    //     }
    //
    //     private void HandleLogging(LogLevel level, string message, Exception e)
    //     {
    //         if (string.IsNullOrWhiteSpace(message))
    //             message = $"Error throw within ProductOptionRepository, Exception: {e.Message}";
    //
    //         _logger.Log(level, message);
    //         throw new ProductApiValidationException(message, e ?? new Exception());
    //     }
    }
}