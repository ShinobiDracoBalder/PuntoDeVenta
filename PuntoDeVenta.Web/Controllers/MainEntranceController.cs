using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Web.DataBase;
using PuntoDeVenta.Web.Helpers;
using PuntoDeVenta.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.Controllers
{
    public class MainEntranceController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public MainEntranceController(DataContext dataContext, ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var model = await _dataContext.Entrada
                .Include(p=>p.cState)
                .Include(p => p.DetalleEntradas)
                .ThenInclude(p => p.Producto).OrderByDescending(o => o.Fecha)
                .ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = await _dataContext
                .tblTmpDetailenter
                .Include(tm => tm.Product)
                .ToListAsync();

            var view = new NewOrderView
            {
                Date = DateTime.Now,
                ComboProdStates = _combosHelper.GetCombocStates(),
                Details = model.ToList(),
            };

            return this.View(view);
        }
        public ActionResult AddProduct()
        {
            var model = new AddItemViewModel
            {
                Quantity = 1,
                UnitCost = 0,
                Products = _combosHelper.GetComboProducts(),
            };
            return PartialView("_AddProduct", model);
        }
        //public IActionResult AddProduct()
        //{
        //    var model = new AddItemViewModel
        //    {
        //        Quantity = 1,
        //        UnitCost =  0,
        //        Products = _combosHelper.GetComboProducts(),
        //    };

        //    return View(model);
        //}
    }
}
