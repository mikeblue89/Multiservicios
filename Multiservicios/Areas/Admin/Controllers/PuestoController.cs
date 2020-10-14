using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models.ViewModels;

namespace Multiservicios.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PuestoController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public PuestoItemViewModel PuestoItemVm { get; set; }

        public PuestoController(ApplicationDbContext db)
        {
            _db = db;
            PuestoItemVm = new PuestoItemViewModel()
            {
                Departamento = _db.Departamento,
                Puesto = new Models.Puesto()
            };
        }
        //GET
        public async Task<IActionResult> Index()
        {
            var puestoItems = await _db.Puesto.Include(m => m.Departamento).Include(m => m.AreaTrabajo).ToListAsync();
            return View(puestoItems);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View(PuestoItemVm);
        }


        // POST - CREATE
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            PuestoItemVm.Puesto.AreaTrabajoId = Convert.ToInt32(Request.Form["AreaTrabajoId"].ToString());

            if (!ModelState.IsValid)
            {
                return View(PuestoItemVm);
            }

            _db.Puesto.Add(PuestoItemVm.Puesto);
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

            PuestoItemVm.Puesto = await _db.Puesto.Include(m => m.Departamento).Include(m => m.AreaTrabajo).SingleOrDefaultAsync(m => m.Id == id);
            PuestoItemVm.AreaTrabajo = await _db.AreaTrabajo.Where(s => s.DepartamentoId == PuestoItemVm.Puesto.DepartamentoId).ToListAsync();

            if (PuestoItemVm.Puesto == null)
            {
                return NotFound();
            }
            return View(PuestoItemVm);
        }


        // POST - EDIT
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PuestoItemVm.Puesto.AreaTrabajoId = Convert.ToInt32(Request.Form["AreaTrabajoId"].ToString());

            if (!ModelState.IsValid)
            {
                return View(PuestoItemVm);
            }

            _db.Puesto.Add(PuestoItemVm.Puesto);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
