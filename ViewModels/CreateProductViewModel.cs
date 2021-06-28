using System;
using System.ComponentModel.DataAnnotations;
using BaltaShop.Products.Models;

namespace BaltaShop.Products.ViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int QuantityOnHand { get; set; }

        public Product ToProduct() => new()
        {
            Id = 0,
            Title = Title,
            Summary = Summary,
            Description = Description,
            Price = Price,
            QuantityOnHand = QuantityOnHand,
            CreateDate = DateTime.Now,
            LastUpdateDate = DateTime.Now,
            Active = false
        };
    }
}
