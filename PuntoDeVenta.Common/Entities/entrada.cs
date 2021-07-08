using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PuntoDeVenta.Common.Entities
{
    public class entrada : BaseEntity
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime? Fecha { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}")]
        [Display(Name = "Date")]
        public DateTime? DateEnterLocal => Fecha?.ToLocalTime();

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal Total { get; set; }
       
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Usted debe de seleccionar un State.")]
        public int idState { get; set; }

        [JsonIgnore]
        [ForeignKey("idState")]
        public virtual cState cState { get; set; }
        public ICollection<detalle_entrada> DetalleEntradas { get; set; }

        [NotMapped]
        public IEnumerable<detalle_entrada> Items { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Lines { get { return this.Items == null ? 0 : this.Items.Count(); } }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get { return this.Items == null ? 0 : this.Items.Sum(i => i.cantidad); } }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Value); } }
    }
}
