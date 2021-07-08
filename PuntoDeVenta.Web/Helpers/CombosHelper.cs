using Microsoft.AspNetCore.Mvc.Rendering;
using PuntoDeVenta.Web.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.Helpers
{
    public class CombosHelper: ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetCombocStates()
        {
            var list = _dataContext.cState
                  .Select(pt => new SelectListItem
                  {
                      Text = pt.nombre,
                      Value = $"{pt.id}"
                  })
                   .OrderBy(pt => pt.Text)
                   .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a  State...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = _dataContext.Producto
                 .Select(p => new SelectListItem
                 {
                     Text = p.Nombre,
                     Value = $"{p.Id}"
                 })
                  .OrderBy(pt => pt.Text)
                  .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Product...)",
                Value = "0"
            });

            return list;
        }
    }
}
