using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PuntoDeVenta.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetCombocStates();
        IEnumerable<SelectListItem> GetComboProducts();

    }
}
