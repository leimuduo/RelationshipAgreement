using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public async Task<IActionResult> Get(string name)
        // {
        //     if (string.IsNullOrWhiteSpace(name))
        //     {
        //         var products = await _productService.GetAllProducts();
        //         return Ok(new ProductsDto {Items = products});
        //     }
        //     else
        //     {
        //         var products = await _productService.GetProductsByName(name);
        //         return Ok(new ProductsDto {Items = products});
        //     }
        // }
        //
        // [HttpGet("{id}", Name = "GetProduct")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> Get(Guid id)
        // {
        //     if (!GeneralGuidCheck(id)) return BadRequest($"invalid product Id {id}");
        //
        //     var product = await _productService.GetProductById(id);
        //
        //     return product == null ? NotFound("Product not found.") : Ok(product);
        // }
        //
        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> Post(ProductDto product)
        // {
        //     var createdProduct = await _productService.CreateProduct(product);
        //     return Created("GetProduct", createdProduct.Id);
        // }
        //
        // [HttpPut("{id}")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> Update(Guid id, [FromBody] ProductDto product)
        // {
        //     if (!GeneralGuidCheck(id)) return BadRequest($"invalid product Id {id}");
        //
        //     if (id != product.Id)
        //         return BadRequest($"Provide ID {id} does not match update product's id {product.Id}.");
        //
        //     var updatedProduct = await _productService.UpdateProduct(product);
        //     return Ok(updatedProduct);
        // }
        //
        // [HttpDelete("{id}")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public async Task<IActionResult> Delete(Guid id)
        // {
        //     if (!GeneralGuidCheck(id)) return BadRequest($"invalid product Id {id}");
        //
        //     await _productService.DeleteProduct(id);
        //     return Ok();
        // }
        //
        // private bool GeneralGuidCheck(Guid id)
        // {
        //     return id != Guid.Empty;
        // }
    }
}