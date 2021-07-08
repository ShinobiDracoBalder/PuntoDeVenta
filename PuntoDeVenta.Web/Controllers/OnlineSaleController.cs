using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Web.DataBase;
using PuntoDeVenta.Web.Helpers;
using PuntoDeVenta.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.Controllers
{
    public class OnlineSaleController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public OnlineSaleController(DataContext dataContext, ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var model = await _dataContext.Venta
                .Include(p => p.cState)
                .Include(p => p.DetalleVentas)
                .ThenInclude(p => p.Producto).OrderByDescending(o => o.Fecha)
                .ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var model = await _dataContext
            .tblTmpDetailSales
            .Include(tm => tm.Product)
            .ToListAsync();

            var view = new NewSaleView
            {
                Date = DateTime.Now,
                ComboProdStates = _combosHelper.GetCombocStates(),
                Details = model.ToList(),
            };

            return this.View(view);
        }

        public IActionResult Create()
        {
            try
            {
                

                var view = new NewSaleView
                {
                    Date = DateTime.Now,
                    ComboProdStates = _combosHelper.GetCombocStates(),
                    //Details = model.ToList(),
                };
                return PartialView("_Create", view);
            }
            catch (Exception ex)
            {

                throw;

            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(NewSaleView model)
        {
            //validate user  
            if (!ModelState.IsValid)
                return PartialView("_Create", model);


            //save user into database   
            return RedirectToAction("index");
        }
    }
}
