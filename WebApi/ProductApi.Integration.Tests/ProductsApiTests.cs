using System;
using System.Net;
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
    public class ProductsApiTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductsApiTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllProductsReturnsProductsResponse()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/api/products");

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<ProductsDto>(stringResponse);
            Assert.Equal(3, products.Items.Count);
            Assert.Contains(products.Items, p => p.Name == "test1");
            Assert.Contains(products.Items, p => p.Name == "test2");
        }

        [Fact]
        public async Task GetProductByIdReturnsProductResponse()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/api/products/a2228364-c9b5-4cb4-8c9f-3c4be4d0938a");

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(stringResponse);
            Assert.Equal("test1", product.Name);
        }

        [Fact]
        public async Task GetProductByIdReturnsNotFoundWhenProductNotExist()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/api/products/39cbc408-505d-4d66-8ca0-4a0bb7787ea4");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetProductsByNameReturnsProductResponse()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/api/products?name=test1");

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<ProductsDto>(stringResponse);
            Assert.Single(products.Items);
            Assert.Equal(Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0938a"), products.Items[0].Id);
            Assert.Equal("test1", products.Items[0].Name);
        }

        [Fact]
        public async Task CreateProductReturnsProductResponse()
        {
            // Arrange
            var newProduct = new Product
            {
                Name = "test3",
                Description = "test3 description",
                Price = 11.99M,
                DeliveryPrice = 7.99M
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/products?name=test1", newProduct);

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var productGuid = JsonConvert.DeserializeObject<Guid>(stringResponse);
            Assert.NotEqual(Guid.Empty, productGuid);
        }

        [Fact]
        public async Task UpdateProductReturnsProductResponse()
        {
            // Arrange
            var updateProduct = new Product
            {
                Id = Guid.Parse("a2228364-c9b5-4cb4-8c9f-3c4be4d0938a"),
                Name = "test1",
                Description = "test1 description updated",
                Price = 12.99M,
                DeliveryPrice = 8.99M
            };

            // Act
            var response =
                await _client.PutAsJsonAsync("/api/products/a2228364-c9b5-4cb4-8c9f-3c4be4d0938a", updateProduct);

            // Assert
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(stringResponse);
            Assert.Equal(updateProduct.Description, product.Description);
            Assert.Equal(updateProduct.Price, product.Price);
            Assert.Equal(updateProduct.DeliveryPrice, product.DeliveryPrice);
        }

        [Fact]
        public async Task UpdateProductReturnsNotFoundWhenProductNotExist()
        {
            // Arrange
            var updateProduct = new Product
            {
                Id = Guid.Parse("39cbc408-505d-4d66-8ca0-4a0bb7787ea4"),
                Name = "test3",
                Description = "test3 description updated",
                Price = 12.99M,
                DeliveryPrice = 8.99M
            };

            // Act
            var response =
                await _client.PutAsJsonAsync("/api/products/39cbc408-505d-4d66-8ca0-4a0bb7787ea4", updateProduct);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProductReturnsBadRequestWhenProductDataIsInvalid()
        {
            // Arrange
            var updateProduct = new Product
            {
                DeliveryPrice = 8.99M
            };

            // Act
            var response =
                await _client.PutAsJsonAsync("/api/products/a2228364-c9b5-4cb4-8c9f-3c4be4d0938a", updateProduct);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteProductReturnsOkResponse()
        {
            // Arrange
            // Act
            var response = await _client.DeleteAsync("/api/products/a2228364-c9b5-4cb4-8c9f-3c4be4d0938b");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}