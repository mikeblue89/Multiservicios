using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models;

namespace Multiservicios.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class MarcaController : Controller
    {

        private readonly ApplicationDbContext _db;

        public MarcaController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        
        public async  Task<IActionResult> Index()
        {
            return View(await _db.Marca.ToListAsync());
        }

        //GET Crear Marca
        public IActionResult Create()
        {
            return View();
        }

        // Metodo POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Marca Marca)
        {
            if (ModelState.IsValid)
            {
                //Si los campos son validos
                _db.Marca.Add(Marca);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(Marca);
        }

        //GET  EDITAR

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var marca = await _db.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();

            }
            return View(marca);
        }

        //POST  EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _db.Update(marca);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }


        //GET - Borrar

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var marca = await _db.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        //POST - Borar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await _db.Marca.FindAsync(id);

            if (marca == null)
            {
                return View();
            }
            _db.Marca.Remove(marca);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
