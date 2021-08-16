using System;
using System.ComponentModel.DataAnnotations;

namespace RelationshipApi.Models.Entities
{
    public class ProductOption
    {
        public Guid Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }


        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}