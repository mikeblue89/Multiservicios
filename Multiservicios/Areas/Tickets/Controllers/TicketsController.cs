using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models;
using Multiservicios.Models.ViewModels;

namespace Multiservicios.Areas.Tickets.Controllers
{
    [Area("Tickets")]
    public class TicketsController : Controller
    {

        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public TicketsItemViewModel TicketsItemVm { get; set; }
        public TicketsController(ApplicationDbContext db)
        {
            _db = db;
            TicketsItemVm = new TicketsItemViewModel()
            {
                Activo = _db.Activo,
                TipoSolicitud = _db.TipoSolicitud,
                Tickets = new Models.Tickets()
            };
        }

        //GET
        public async Task<IActionResult> Index()
        {
            var TicketsItems = await _db.Tickets.Include(s => s.Activo).Include(s => s.TipoSolicitud).ToListAsync();
            return View(TicketsItems);
        }
        // GET - Create
        public IActionResult Create()
        {
            return View(TicketsItemVm);
        }

        //POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tickets_ActivoViewModel model)
        {

            TicketsItemVm.Tickets.TIPO_SERVICIO = Request.Form["TIPO_SERVICIO"].ToString();

            if (!ModelState.IsValid)
            {
                return View(TicketsItemVm);
            }

            TicketsItemVm.Tickets.FECHA_CREACION = DateTime.Now.ToString();
            TicketsItemVm.Tickets.TIPO_SERVICIO = Request.Form["TIPO_SERVICIOSelect"].ToString();
            TicketsItemVm.Tickets.USUARIO_CREACION = 5005;
            TicketsItemVm.Tickets.ESTADO = "Activo";

            _db.Tickets.Add(TicketsItemVm.Tickets);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        //GET - EDIT

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Tickets = await _db.Tickets.FindAsync(id);
            if (Tickets == null)
            {
                return NotFound();
            }

            return View(Tickets);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Tickets_ActivoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _db.Update(model.Tickets);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model.Tickets);
        }

        //GET - DELETE

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Tickets = await _db.Tickets.FindAsync(id);
            if (Tickets == null)
            {
                return NotFound();
            }

            return View(Tickets);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Tickets = await _db.Tickets.FindAsync(id);

            if (Tickets == null)
            {
                return View();
            }
            _db.Tickets.Remove(Tickets);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
