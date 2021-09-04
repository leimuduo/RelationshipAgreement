namespace RelationshipApi.Services.Implementation
{
    public class ProductOptionService
    {
        // private readonly ILogger<ProductOptionService> _logger;
        // private readonly IProductOptionRepository _productOptionRepo;
        // private readonly IProductRepository _productRepo;
        //
        //
        // public ProductOptionService(IProductRepository productRepo,
        //     IProductOptionRepository productOptionRepo, ILogger<ProductOptionService> logger)
        // {
        //     _productRepo = productRepo;
        //     _productOptionRepo = productOptionRepo;
        //     _logger = logger;
        // }
        //
        // /// <summary>
        // ///     Method for fetching product option by option Id.
        // ///     Null will be return if no option found.
        // /// </summary>
        // /// <param name="id"></param>
        // /// <returns></returns>
        // public async Task<ProductOptionDto> GetProductOptionById(Guid id)
        // {
        //     return await _productOptionRepo.GetProductOptionById(id);
        // }
        //
        // /// <summary>
        // ///     Method for getting all product options by providing product id
        // ///     Null will be return if there's no options attached to specified product.
        // /// </summary>
        // /// <param name="productId"></param>
        // /// <returns></returns>
        // public async Task<List<ProductOptionDto>> GetAllProductOptionsByProductId(Guid productId)
        // {
        //     return await _productOptionRepo.GetAllProductOptionsByProductId(productId);
        // }
        //
        // /// <summary>
        // ///     Method for creating new product option.
        // ///     If product can not be found, it will throw exception.
        // ///     If productOption's productId doesn't match product's id, it will throw exception.
        // /// </summary>
        // /// <param name="option"></param>
        // /// <returns></returns>
        // public async Task<ProductOptionDto> CreateProductOption(ProductOptionDto option)
        // {
        //     await ValidateProductId(option.ProductId);
        //
        //     var newOption = await _productOptionRepo.CreateProductOption(option);
        //
        //     await ValidateProductOption(newOption.ProductId, newOption.Id);
        //
        //     return newOption;
        // }
        //
        // /// <summary>
        // ///     Method to update product option by providing productId, target option.
        // ///     option.productId and productId should be validated on controller level.
        // /// </summary>
        // /// <param name="option"></param>
        // /// <returns></returns>
        // public async Task<ProductOptionDto> UpdateProductOption(ProductOptionDto option)
        // {
        //     await ValidateProductId(option.ProductId);
        //     await ValidateProductOption(option.ProductId, option.Id);
        //     var result = await _productOptionRepo.UpdateProductOption(option);
        //
        //     return result;
        // }
        //
        // public async Task<bool> DeleteProductOption(Guid optionId)
        // {
        //     return await _productOptionRepo.DeleteProductOption(optionId);
        // }
        //
        // /// <summary>
        // ///     Due to product to productOption is 1-to-N relationship,
        // ///     we have to make sure each option attaches to one product.
        // ///     For now there's only used while create/update productOption.
        // ///     Please extend or update definition once extend usage in the future.
        // /// </summary>
        // /// <param name="productId"></param>
        // /// <exception cref="Exception"></exception>
        // private async Task ValidateProductId(Guid productId)
        // {
        //     var product = await _productRepo.GetProductById(productId);
        //
        //     if (product == null)
        //     {
        //         var msg = $"Can not find product with id {productId}.";
        //         _logger.LogError(msg);
        //         throw new ProductApiValidationException(msg);
        //     }
        // }
        //
        // private async Task ValidateProductOption(Guid productId, Guid optionId)
        // {
        //     if (productId == Guid.Empty)
        //     {
        //         var msg = "Product Id can not be empty.";
        //         _logger.LogError(msg);
        //         throw new ProductApiValidationException(msg);
        //     }
        //
        //     if (optionId == Guid.Empty)
        //     {
        //         var msg = "Product option Id can not be empty.";
        //         _logger.LogError(msg);
        //         throw new ProductApiValidationException(msg);
        //     }
        //
        //     var result = await _productOptionRepo.GetProductOptionById(optionId);
        //
        //     if (result == null)
        //     {
        //         var msg = $"Can not find product option {optionId} under product {productId}.";
        //         _logger.LogError(msg);
        //         throw new ProductApiValidationException(msg);
        //     }
        //
        //     if (result.ProductId != productId)
        //     {
        //         var msg =
        //             $"Product Option (Id:{optionId})'s product ID doesn't match provided product Id {productId}. ";
        //         _logger.LogError(msg);
        //         throw new ProductApiValidationException(msg);
        //     }
        // }
    }
}