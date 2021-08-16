using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductApi;
using ProductApi.Integration.Tests;
using ProductApi.Models.Dtos;
using ProductApi.Models.Entities;
using Xunit;

namespace ProductsApi.Integration.Tests
{
    public class ProductOptionsApiTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly string _productUri;

        public ProductOptionsApiTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            var productId = "a2228364-c9b5-4cb4-8c9f-3c4be4d0938a";
            _productUri = $"/api/products/{productId}/options";
        }

        [Fact]
        public async Task GetAllProductOptionsReturnsProductOptionsResponse()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync(_productUri);

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var productOptions = JsonConvert.DeserializeObject<ProductOptionsDto>(stringResponse);

            Assert.Equal(2, productOptions.Items.Count);
            Assert.Contains(productOptions.Items, p => p.Description == "Black");
            Assert.Contains(productOptions.Items, p => p.Description == "White");
        }

        [Fact]
        public async Task GetProductOptionByIdReturnsProductOptionResponse()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync($"{_productUri}/a2228364-c9b5-4cb4-8c9f-3c4be4d0456b");

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var productOption = JsonConvert.DeserializeObject<ProductOptionDto>(stringResponse);
            Assert.Equal("White", productOption.Description);
        }

        [Fact]
        public async Task CreateProductOptionReturnsProductOptionResponse()
        {
            // Arrange
            var newProductOption = new ProductOption
            {
                ProductId = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0938a"),
                Name = "Colour",
                Description = "Pink"
            };

            // Act
            var response = await _client.PostAsJsonAsync(_productUri, newProductOption);

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var productOption = JsonConvert.DeserializeObject<ProductOptionDto>(stringResponse);

            Assert.Equal(newProductOption.Name, productOption.Name);
            Assert.Equal(newProductOption.Description, productOption.Description);
        }

        [Fact]
        public async Task UpdateProductOptionReturnsProductResponse()
        {
            // Arrange
            var updateProductOption = new ProductOption
            {
                Id = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0456b"),
                ProductId = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0938a"),
                Name = "Colour",
                Description = "Yellow"
            };

            // Act
            var response = await _client.PutAsJsonAsync($"{_productUri}/a2228364-c9b5-4cb4-8c9f-3c4be4d0456b",
                updateProductOption);

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var productOption = JsonConvert.DeserializeObject<ProductOptionDto>(stringResponse);

            Assert.Equal(updateProductOption.Description, productOption.Description);
        }

        [Fact]
        public async Task DeleteProductReturnsOkResponse()
        {
            // Arrange
            // Act
            var response = await _client.DeleteAsync($"{_productUri}/a2228364-c9b5-4cb4-8c9f-3c4be4d0938c");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}