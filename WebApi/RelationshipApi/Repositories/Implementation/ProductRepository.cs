using RelationshipApi.Repositories.Interfaces;

namespace RelationshipApi.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        // private readonly ProductsContext _context;
        // private readonly ILogger<ProductRepository> _logger;
        // private readonly IMapper _mapper;
        //
        // public ProductRepository(ProductsContext context, IMapper mapper, ILogger<ProductRepository> logger)
        // {
        //     _context = context;
        //     _mapper = mapper;
        //     _logger = logger;
        // }
        //
        // /// <summary>
        // ///     This is method to fetch product by product ID.
        // ///     Only active product will be return.
        // /// </summary>
        // /// <param name="productId"></param>
        // /// <returns></returns>
        // public async Task<ProductDto> GetProductById(Guid productId)
        // {
        //     var product = await _context.Products
        //         .Where(p => p.Id == productId && p.Status == (int) ProductStatusEnum.Active)
        //         .Include(p => p.ProductOptions)
        //         .FirstOrDefaultAsync();
        //
        //     if (product == null)
        //         // For providing more info about user behaviour. In case client side cache legacy id or other cases.
        //         HandleLogging(LogLevel.Information, $"ProductId {productId} return null result");
        //
        //     return _mapper.Map<Product, ProductDto>(product);
        // }
        //
        // /// <summary>
        // ///     This method is for fetching all active product.
        // /// </summary>
        // /// <returns></returns>
        // public async Task<List<ProductDto>> GetAllProducts()
        // {
        //     var products = await _context.Products
        //         .Where(p => p.Status != (int) ProductStatusEnum.Inactive)
        //         .ToListAsync();
        //     return _mapper.Map<List<Product>, List<ProductDto>>(products);
        // }
        //
        // public async Task<List<ProductDto>> GetProductsByName(string name)
        // {
        //     var products = await _context.Products
        //         .Where(p => p.Status != (int) ProductStatusEnum.Inactive)
        //         .Where(p => string.Equals(name, p.Name))
        //         .Include(p => p.ProductOptions)
        //         .ToListAsync();
        //     return _mapper.Map<List<Product>, List<ProductDto>>(products);
        // }
        //
        // /// <summary>
        // ///     Method for creating new Product.
        // ///     Validation against duplication, etc should be done on services level.
        // /// </summary>
        // /// <param name="product"></param>
        // /// <returns></returns>
        // public async Task<ProductDto> CreateProduct(ProductDto product)
        // {
        //     var entity = _mapper.Map<ProductDto, Product>(product);
        //     entity.Status = (int) ProductStatusEnum.Active;
        //
        //     try
        //     {
        //         var newCreatedProduct = await _context.Products.AddAsync(entity);
        //         await _context.SaveChangesAsync();
        //         return _mapper.Map<Product, ProductDto>(newCreatedProduct.Entity);
        //     }
        //     catch (Exception e)
        //     {
        //         HandleLogging(LogLevel.Error, "Fail to create product.", e);
        //     }
        //
        //     return null;
        // }
        //
        // /// <summary>
        // ///     This is method for updating product.
        // ///     Only Active Product could be updated.
        // ///     Exception would be thrown if can't find product via provided ID.
        // ///     Exception would be thrown if attempt to update disable product.
        // /// </summary>
        // /// <param name="product"></param>
        // /// <returns></returns>
        // public async Task<ProductDto> UpdateProduct(ProductDto product)
        // {
        //     try
        //     {
        //         var source = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
        //         if (source == null) HandleLogging(LogLevel.Error, $"Can not find product {product.Id} during update.");
        //
        //         if (source.Status == (int) ProductStatusEnum.Inactive)
        //             HandleLogging(LogLevel.Error, $"Can not update product {product.Id} due to it's inactive.");
        //
        //         source.Name = product.Name;
        //         source.Description = product.Description;
        //         source.Price = product.Price;
        //         source.DeliveryPrice = product.DeliveryPrice;
        //         await _context.SaveChangesAsync();
        //
        //         return _mapper.Map<Product, ProductDto>(source);
        //     }
        //     catch (Exception e)
        //     {
        //         HandleLogging(LogLevel.Error, $"Fail to update product {product.Id}.", e);
        //     }
        //
        //     return null;
        // }
        //
        // public async Task<bool> DeleteProduct(Guid id)
        // {
        //     try
        //     {
        //         var source = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        //         if (source == null) HandleLogging(LogLevel.Error, $"Can not find product {id} during deleting.");
        //
        //         source.Status = (int) ProductStatusEnum.Inactive;
        //         _context.Products.Update(source);
        //         await _context.SaveChangesAsync();
        //         return true;
        //     }
        //     catch (Exception e)
        //     {
        //         HandleLogging(LogLevel.Error, $"Fail to remove product {id}.", e);
        //     }
        //
        //     return false;
        // }
        //
        // private void HandleLogging(LogLevel level, string message, Exception e = null)
        // {
        //     if (string.IsNullOrWhiteSpace(message))
        //         message = $"Error throw within ProductRepository, Exception: {e?.Message}";
        //
        //     _logger.Log(level, message);
        //     if (level == LogLevel.Error) throw new ProductApiValidationException(message, e ?? new Exception());
        // }
    }
}