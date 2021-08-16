using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Controllers
{
    [Route("api/products/{productId}/options")]
    [ApiController]
    public class ProductOptionsController : ControllerBase
    {
        private readonly IProductOptionService _productOptionService;
        private readonly IProductService _productService;

        public ProductOptionsController(IProductService productService, IProductOptionService productOptionService)
        {
            _productService = productService;
            _productOptionService = productOptionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOptions(Guid productId)
        {
            if (!GeneralGuidCheck(productId)) return BadRequest($"invalid Id {productId}");

            if (await _productService.GetProductById(productId) == null) return NotFound("Product not found");

            var productOptions = await _productOptionService.GetAllProductOptionsByProductId(productId);

            return Ok(new ProductOptionsDto {Items = productOptions});
        }

        [HttpGet("{id}", Name = "GetProductOption")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOption(Guid productId, Guid id)
        {
            if (!GeneralGuidCheck(productId)) return BadRequest($"invalid Id {productId}");

            if (!GeneralGuidCheck(productId)) return BadRequest($"invalid Option Id {id}");

            var productOption = await _productOptionService.GetProductOptionById(id);

            if (productOption == null) return NotFound($"Product option not found. Option Id: {id}");

            return Ok(productOption);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateOption(Guid productId, [FromBody] ProductOptionDto option)
        {
            if (!GeneralGuidCheck(productId)) return BadRequest($"invalid Id {productId}");

            if (option.ProductId != productId) return BadRequest("Product Id does not match.");

            var createdOption = await _productOptionService.CreateProductOption(option);

            return Ok(createdOption);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOption(Guid productId, [FromBody] ProductOptionDto option)
        {
            if (!GeneralGuidCheck(productId)) return BadRequest($"invalid Id {productId}");

            if (!GeneralGuidCheck(option.Id)) return BadRequest($"invalid Option Id {option.Id}");

            if (option.ProductId != productId) return BadRequest("Product Id does not match.");

            var updatedProductOption = await _productOptionService.UpdateProductOption(option);

            return Ok(updatedProductOption);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOption(Guid id)
        {
            if (!GeneralGuidCheck(id)) return BadRequest($"invalid Option Id {id}");

            await _productOptionService.DeleteProductOption(id);
            return Ok();
        }

        private bool GeneralGuidCheck(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}