using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PuntoDeVenta.Web.Models
{
    public class AddItemViewModel
    {
        [Display(Name = "Product")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a product.")]
        public int ProductId { get; set; }

        [Range(0.0001, int.MaxValue, ErrorMessage = "The quantiy must be a positive number")]
        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal UnitCost { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
