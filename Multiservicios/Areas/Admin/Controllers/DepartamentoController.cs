using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models;

namespace Multiservicios.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartamentoController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DepartamentoController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.Departamento.ToListAsync());
        }

        // GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamento Departamento)
        {
            if (ModelState.IsValid)
            {
                //if valid
                _db.Departamento.Add(Departamento);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(Departamento);
        }

        //GET - EDIT

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _db.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _db.Update(departamento);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        //GET - DELETE

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _db.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _db.Departamento.FindAsync(id);

            if (departamento == null)
            {
                return View();
            }
            _db.Departamento.Remove(departamento);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
