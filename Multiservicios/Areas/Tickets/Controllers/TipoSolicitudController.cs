using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models;

namespace Multiservicios.Areas.Tickets.Controllers
{
    [Area("Tickets")]
    public class TipoSolicitudController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TipoSolicitudController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET

        public async Task<IActionResult> Index()
        {
            return View(await _db.TipoSolicitud.ToListAsync());
        }

        //GET Crear Marca
        public IActionResult Create()
        {
            return View();
        }

        // Metodo POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoSolicitud TipoSolicitud)
        {
            if (ModelState.IsValid)
            {
                //Si los campos son validos
                _db.TipoSolicitud.Add(TipoSolicitud);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(TipoSolicitud);
        }

        //GET  EDITAR

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var TipoSolicitud = await _db.TipoSolicitud.FindAsync(id);
            if (TipoSolicitud == null)
            {
                return NotFound();

            }
            return View(TipoSolicitud);
        }

        //POST  EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(TipoSolicitud TipoSolicitud)
        {
            if (ModelState.IsValid)
            {
                _db.Update(TipoSolicitud);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(TipoSolicitud);
        }


        //GET - Borrar

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var TipoSolicitud = await _db.TipoSolicitud.FindAsync(id);
            if (TipoSolicitud == null)
            {
                return NotFound();
            }

            return View(TipoSolicitud);
        }

        //POST - Borar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TipoSolicitud = await _db.TipoSolicitud.FindAsync(id);

            if (TipoSolicitud == null)
            {
                return View();
            }
            _db.TipoSolicitud.Remove(TipoSolicitud);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
