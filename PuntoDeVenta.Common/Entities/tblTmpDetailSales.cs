using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PuntoDeVenta.Common.Entities
{
    public class tblTmpDetailSales
    {
        [Key]
        public int TmpDetailSaleId { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Usted debe de seleccionar un Unit Cost.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitCost { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Usted debe de seleccionar un Unit Price.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un Amunt.")]
        public int Amount { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un Product.")]
        public int idProducto { get; set; }

        [Required]
        public Producto Product { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Value { get { return this.UnitCost * (decimal)this.Amount; } }
    }
}
