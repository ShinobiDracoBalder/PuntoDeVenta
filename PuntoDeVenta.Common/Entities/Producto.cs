using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PuntoDeVenta.Common.Entities
{
    public class Producto : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
       
        public DateTime? Fecha { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [Display(Name = "Date")]
        public DateTime? DateLocal => Fecha?.ToLocalTime();

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal Precio { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal  Costo { get; set; }
        [Required]
        public int Existencia { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un State.")]
        public int idState { get; set; }

        [JsonIgnore]
        [ForeignKey("idState")]
        public virtual cState cState { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value => (decimal)Existencia * Precio;
        
        public ICollection<detalle_venta>  DetalleVentas { get; set; }
        public ICollection<detalle_entrada> DetalleEntradas { get; set; }
    }
}
