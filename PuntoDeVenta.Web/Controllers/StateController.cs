using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Common.Entities;
using PuntoDeVenta.Web.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoDeVenta.Web.Controllers
{
    public class StateController : Controller
    {
        private readonly IcStateService _stateService;

        public StateController(IcStateService stateService)
        {
            _stateService = stateService;
        }
        // GET: StateController
        public async Task<IActionResult> Index()
        {
            return View(await _stateService.GetAllcStates());
        }

        // GET: StateController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _stateService.GetcStateById(id));
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(cState collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _stateService.CreatecStateAsync(collection);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(collection);
        }

        // GET: StateController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _stateService.GetcStateById(id.Value));
        }

        // POST: StateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, cState collection)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var dbState = await _stateService.GetcStateById(id.Value);
                    if (await TryUpdateModelAsync<cState>(dbState))
                    {
                        await _stateService.UpdatecStateAsync(dbState);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("","Unable to save changes.");
            }
            return View(collection);
        }

        // GET: StateController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var dbState = await _stateService.GetcStateById(id.Value);
                if (dbState != null)
                {
                    await _stateService.DeletecStateAsync(dbState);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: StateController/Delete/5
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
