using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PuntoDeVenta.Common.Entities
{
    public class detalle_venta : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal costo_unitario { get; set; }
        public decimal precio_unitario { get; set; }
        public int cantidad { get; set; }
        public int id_venta { get; set; }
        public int idProducto { get; set; }

        [JsonIgnore]
        [ForeignKey("id_venta")]
        public virtual venta Venta{ get; set; }

        [JsonIgnore]
        [ForeignKey("idProducto")]
        public virtual Producto Producto { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [NotMapped]
        public decimal Value { get { return this.costo_unitario * (decimal)this.cantidad; } }
    }
}
