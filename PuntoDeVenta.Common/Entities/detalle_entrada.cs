using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Common.Entities
{
    public class detalle_entrada : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal costo_unitario { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int cantidad { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un State.")]
        public int idProducto { get; set; }

        [JsonIgnore]
        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un State.")]
        public int id_entrada { get; set; }

        [JsonIgnore]
        [ForeignKey("id_entrada")]
        public virtual entrada Entrada { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [NotMapped]
        public decimal Value { get { return this.costo_unitario * (decimal)this.cantidad; } }
    }
}
