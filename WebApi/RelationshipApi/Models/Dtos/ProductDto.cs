using System;
using System.Collections.Generic;

namespace RelationshipApi.Models.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public IEnumerable<ProductOptionDto> ProductOptions { get; set; }
    }
}