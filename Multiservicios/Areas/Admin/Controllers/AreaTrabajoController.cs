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

namespace Multiservicios.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AreaTrabajoController : Controller
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        public AreaTrabajoController( ApplicationDbContext db)
        {
            _db = db;
        }

        //GET - INDEX
        public async Task<IActionResult> Index()
        {
            var areasDeTrabajo = await _db.AreaTrabajo.Include(s => s.Departamento).ToListAsync();
            return View(areasDeTrabajo);
        }

        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            DepartamentoAndAreaTrabajoViewModel model = new DepartamentoAndAreaTrabajoViewModel()
            {
                DepartamentoList = await _db.Departamento.ToListAsync(),
                AreaTrabajo = new Models.AreaTrabajo(),
                AreaTrabajoList = await _db.AreaTrabajo.OrderBy(p => p.Nombre).Select(p => p.Nombre).Distinct().ToListAsync()
            };

            return View(model);

        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartamentoAndAreaTrabajoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesAreaTrabajoExists = _db.AreaTrabajo.Include(s => s.Departamento).Where(s => s.Nombre == model.AreaTrabajo.Nombre && s.Departamento.Id == model.AreaTrabajo.DepartamentoId);
                if (doesAreaTrabajoExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error: El Area existe dentro de " + doesAreaTrabajoExists.First().Departamento.Nombre + " ingrese un area diferente";
                }
                else
                {
                    _db.AreaTrabajo.Add(model.AreaTrabajo);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            DepartamentoAndAreaTrabajoViewModel modelVm = new DepartamentoAndAreaTrabajoViewModel()
            {
                DepartamentoList = await _db.Departamento.ToListAsync(),
                AreaTrabajo = model.AreaTrabajo,
                AreaTrabajoList = await _db.AreaTrabajo.OrderBy(p => p.Nombre).Select(p => p.Nombre).ToListAsync(),
                StatusMessage = StatusMessage

            };
            return View(modelVm);
        }

        //Action Method
        [ActionName("GetAreaTrabajo")]
        public async Task<IActionResult> GetAreaTrabajo(int id)
        {
            List<AreaTrabajo> AreasTrabajo = new List<AreaTrabajo>();

            AreasTrabajo = await (from AreaTrabajo in _db.AreaTrabajo
                                   where AreaTrabajo.DepartamentoId == id
                                   select AreaTrabajo).ToListAsync();
            return Json(new SelectList(AreasTrabajo, "Id", "Nombre"));
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AreaTrabajo = await _db.AreaTrabajo.SingleOrDefaultAsync(m => m.Id == id);

            if (AreaTrabajo == null)
            {
                return NotFound();
            }

            DepartamentoAndAreaTrabajoViewModel model = new DepartamentoAndAreaTrabajoViewModel()
            {
                DepartamentoList = await _db.Departamento.ToListAsync(),
                AreaTrabajo = AreaTrabajo,
                AreaTrabajoList = await _db.AreaTrabajo.OrderBy(p => p.Nombre).Select(p => p.Nombre).Distinct().ToListAsync()
            };

            return View(model);

        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartamentoAndAreaTrabajoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesAreaTrabajoExists = _db.AreaTrabajo.Include(s => s.Departamento).Where(s => s.Nombre == model.AreaTrabajo.Nombre && s.Departamento.Id == model.AreaTrabajo.DepartamentoId);
                if (doesAreaTrabajoExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error: Area de Trabajo Existe dentro de " + doesAreaTrabajoExists.First().Departamento.Nombre + " ingrese un area diferente";
                }
                else
                {
                    var AreaTrabajoFromDb = await _db.AreaTrabajo.FindAsync(model.AreaTrabajo.Id);
                    AreaTrabajoFromDb.Nombre = model.AreaTrabajo.Nombre;


                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            DepartamentoAndAreaTrabajoViewModel modelVm = new DepartamentoAndAreaTrabajoViewModel()
            {
                DepartamentoList = await _db.Departamento.ToListAsync(),
                AreaTrabajo = model.AreaTrabajo,
                AreaTrabajoList = await _db.AreaTrabajo.OrderBy(p => p.Nombre).Select(p => p.Nombre).ToListAsync(),
                StatusMessage = StatusMessage

            };
            //modelVm.SubCategory.Id = id;
            return View(modelVm);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaTrabajo = await _db.AreaTrabajo.SingleOrDefaultAsync(m => m.Id == id);

            if (areaTrabajo == null)
            {
                return NotFound();
            }

            DepartamentoAndAreaTrabajoViewModel model = new DepartamentoAndAreaTrabajoViewModel()
            {
                DepartamentoList = await _db.Departamento.ToListAsync(),
                AreaTrabajo = areaTrabajo,
                AreaTrabajoList = await _db.AreaTrabajo.OrderBy(p => p.Nombre).Select(p => p.Nombre).Distinct().ToListAsync()
            };

            return View(model);

        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaTrabajo = await _db.AreaTrabajo.SingleOrDefaultAsync(m => m.Id == id);
            _db.AreaTrabajo.Remove(areaTrabajo);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
