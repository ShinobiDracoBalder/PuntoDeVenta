using Microsoft.AspNetCore.Mvc.Rendering;
using PuntoDeVenta.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.Models
{
    public class AddProductViewModel: Producto
    {
        public IEnumerable<SelectListItem> ComboProdStates { get; set; }
    }
}
