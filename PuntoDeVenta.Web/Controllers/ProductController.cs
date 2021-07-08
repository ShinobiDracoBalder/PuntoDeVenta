using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Common.Entities;
using PuntoDeVenta.Web.DataBase;
using PuntoDeVenta.Web.DataBase.Repositories;
using PuntoDeVenta.Web.Helpers;
using PuntoDeVenta.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IDapper _dapper;
        private readonly ICombosHelper _combosHelper;

        public ProductController(DataContext dataContext, 
            IDapper dapper, ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _dapper = dapper;
            _combosHelper = combosHelper;
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var model = await _dataContext.Producto
                .Include(p => p.cState).ToListAsync();
            return View(model);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _dataContext
                        .Producto
                        .Include(p => p.cState)
                        .Where(p => p.Id == id)
                        .FirstOrDefaultAsync();
            if (model ==null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new AddProductViewModel {
                Fecha = DateTime.Now.ToLocalTime(),
                ComboProdStates = _combosHelper.GetCombocStates(),
            };
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddProductViewModel collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dbparams = new DynamicParameters();

                    dbparams.Add("ProductName", collection.Nombre, DbType.String);
                    dbparams.Add("Fecha", DateTime.Now.ToUniversalTime(), DbType.DateTime);
                    dbparams.Add("StateId", collection.idState, DbType.Int32);
                    dbparams.Add("Price", collection.Precio, DbType.Currency);
                    dbparams.Add("cost", collection.Costo, DbType.Decimal);
                    dbparams.Add("Existence", collection.Existencia, DbType.Int32);
                   
                    var reponse = await Task.FromResult(_dapper.Insert<string>("SP_TblProducts"
                                , dbparams,
                               commandType: CommandType.StoredProcedure));

                    return RedirectToAction(nameof(Index));
                }
                catch(Exception exs)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            collection.ComboProdStates = _combosHelper.GetCombocStates();
            return View(collection);
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdel = await _dataContext.Producto.FindAsync(id);

            if (mdel == null)
            {
                return NotFound();
            }

            var model = new AddProductViewModel
            {
                Id = mdel.Id,
                idState = mdel.idState,
                Nombre = mdel.Nombre,
                Precio = mdel.Precio,
                Costo = mdel.Costo,
                Existencia = mdel.Existencia,
                Fecha = mdel.DateLocal,
                ComboProdStates = _combosHelper.GetCombocStates(),
            };
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AddProductViewModel collection)
        {
            if (ModelState.IsValid) {
                if (id == null)
                {
                    return NotFound();
                }

                try
                {
                    var prod = await _dataContext
                        .Producto
                        .Where(p =>p.Id == id)
                        .FirstOrDefaultAsync();

                    if (prod == null)
                    {
                        return NotFound();
                    }
                    prod.Nombre = prod.Nombre ?? collection.Nombre;
                    prod.Precio = prod.Precio == collection.Precio? prod.Precio:collection.Precio;
                    prod.Existencia = prod.Existencia == collection.Existencia ? prod.Existencia : collection.Existencia;
                    prod.Costo = prod.Costo == collection.Costo ? prod.Costo : collection.Costo;
                    prod.idState = prod.idState == collection.idState ? prod.idState : collection.idState;
                    prod.Fecha = prod.Fecha == collection.Fecha ? prod.Fecha : collection.Fecha;

                    _dataContext.Producto.Update(prod);
                    await _dataContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            collection.ComboProdStates = _combosHelper.GetCombocStates();
            return View(collection);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var prod = await _dataContext
                            .Producto
                            .Where(p => p.Id == id)
                            .FirstOrDefaultAsync();

                _dataContext.Producto.Remove(prod);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
