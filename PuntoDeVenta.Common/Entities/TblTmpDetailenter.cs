using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Common.Entities
{
    public class TblTmpDetailenter
    {
        [Key]
        public int TmpDetailenterId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un Unit Cost.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitCost { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un Quantity.")]
        public int Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un Product.")]
        public int ProductId { get; set; }

        [Required]
        public Producto Product { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Value { get { return this.UnitCost * (decimal)this.Quantity; } }
    }
}
