using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Common.Entities
{
    public class cState : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50, ErrorMessage = "The filed {0} must contain less than {1} characteres.")]
        [Required]
        public string nombre { get; set; }

        public ICollection<Producto> GetProducts { get; set; }
        public ICollection<entrada> GetEntradas { get; set; }
        public ICollection<venta> GetVentas { get; set; }
    }
}
