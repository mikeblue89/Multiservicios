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
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET

        public async Task<IActionResult> Index()
        {
            return View(await _db.Categoria.ToListAsync());
        }

        //GET Crear Marca
        public IActionResult Create()
        {
            return View();
        }

        // Metodo POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria Categoria)
        {
            if (ModelState.IsValid)
            {
                //Si los campos son validos
                _db.Categoria.Add(Categoria);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(Categoria);
        }

        //GET  EDITAR

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoria = await _db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();

            }
            return View(categoria);
        }

        //POST  EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Update(categoria);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }


        //GET - Borrar

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoria = await _db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        //POST - Borar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _db.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return View();
            }
            _db.Categoria.Remove(categoria);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
