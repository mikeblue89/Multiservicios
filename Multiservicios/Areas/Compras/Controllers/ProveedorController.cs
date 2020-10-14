using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models;

namespace Multiservicios.Areas.Compras.Controllers

{
    [Area("Compras")]
    public class ProveedorController : Controller
    {
       
        // GET: ProveedorController
        private readonly ApplicationDbContext _db;

        public ProveedorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Proveedor.ToListAsync());
        }

        //GET Crear Proveedor
        public IActionResult Create()
        {
            return View();
        }

        // Metodo POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                //Si los campos son validos
                _db.Proveedor.Add(proveedor);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(Index()); 
        }


        //GET  EDITAR

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var proveedor = await _db.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();

            }
            return View(proveedor);
        }

        //POST  EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _db.Update(proveedor);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }


        //GET - Borrar

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var proveedor = await _db.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        //POST - Borar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedor = await _db.Proveedor.FindAsync(id);

            if (proveedor == null)
            {
                return View();
            }
            _db.Proveedor.Remove(proveedor);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}