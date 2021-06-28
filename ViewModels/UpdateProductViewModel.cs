using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BaltaShop.Products.Models;

namespace BaltaShop.Products.ViewModels
{
    public class UpdateProductViewModel
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

        [Required]
        public bool Active { get; set; }

        public void Update(Product product)
        {
            product.Title = Title;
            product.Summary = Summary;
            product.Description = Description;
            product.Price = Price;
            product.QuantityOnHand = QuantityOnHand;
            product.LastUpdateDate = DateTime.Now;
            product.Active = Active;
        }
    }
}
