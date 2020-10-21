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
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public UsuarioItemViewModel UsuarioItemVm { get; set; }

        public UsuarioController( ApplicationDbContext db)
        {
            _db = db;
            UsuarioItemVm = new UsuarioItemViewModel()
            {
                Departamento = _db.Departamento,
                AreaTrabajo = _db.AreaTrabajo,
                Puesto = _db.Puesto,
                Usuario = new Models.Usuario()
            };
        }
 
        //GET
        public async Task<IActionResult> Index()
        {
            var UsuarioItems = await _db.Usuario.Include(m => m.Puesto).Include(m => m.AreaTrabajo).Include(m => m.Departamento).ToListAsync();
            return View(UsuarioItems);
        }

        //GET - CREATE
        public IActionResult Create() 
        {
            return View(UsuarioItemVm);
        }

        //POST - CREATE
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            UsuarioItemVm.Usuario.AreaTrabajoId = Convert.ToInt32(Request.Form["AreaTrabajoId"].ToString());
            UsuarioItemVm.Usuario.Role = Request.Form["Role"].ToString();

            if (!ModelState.IsValid)
            {
                return View(UsuarioItemVm);
            }

            UsuarioItemVm.Usuario.FechaCreacion = DateTime.Now;
            UsuarioItemVm.Usuario.FechaMod = DateTime.Now;
            UsuarioItemVm.Usuario.UsuarioCreacion = "Admin";
            UsuarioItemVm.Usuario.UsuarioMod = "Admin";
            UsuarioItemVm.Usuario.Estado = "Activo";

            _db.Usuario.Add(UsuarioItemVm.Usuario);
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

            UsuarioItemVm.Usuario = await _db.Usuario.Include(m => m.Departamento).Include(m => m.AreaTrabajo).Include(m=>m.Puesto).SingleOrDefaultAsync(m => m.Id == id);

            if (UsuarioItemVm.Usuario == null)
            {
                return NotFound();
            }
            return View(UsuarioItemVm);
        }

        //POST - EDIT

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UsuarioItemVm.Usuario.AreaTrabajoId = Convert.ToInt32(Request.Form["AreaTrabajoId"].ToString());
            UsuarioItemVm.Usuario.Role = Request.Form["Role"].ToString();

            if (!ModelState.IsValid)
            {
                UsuarioItemVm.AreaTrabajo = await _db.AreaTrabajo.Where(s => s.DepartamentoId == UsuarioItemVm.Usuario.DepartamentoId).ToListAsync();
                return View(UsuarioItemVm);
            }


            var UsuarioItemFromDb = await _db.Usuario.FindAsync(UsuarioItemVm.Usuario.Id);
            UsuarioItemFromDb.Nombre = UsuarioItemVm.Usuario.Nombre;
            UsuarioItemFromDb.Telefono = UsuarioItemVm.Usuario.Telefono;
            UsuarioItemFromDb.Correo = UsuarioItemVm.Usuario.Correo;
            UsuarioItemFromDb.Role = UsuarioItemVm.Usuario.Role;
            UsuarioItemFromDb.Estado = UsuarioItemVm.Usuario.Estado;
            UsuarioItemFromDb.Password = UsuarioItemVm.Usuario.Password;
            UsuarioItemFromDb.DepartamentoId = UsuarioItemVm.Usuario.DepartamentoId;
            UsuarioItemFromDb.AreaTrabajoId = UsuarioItemVm.Usuario.AreaTrabajoId;
            UsuarioItemFromDb.PuestoId = UsuarioItemVm.Usuario.PuestoId;
            UsuarioItemFromDb.Estado = UsuarioItemVm.Usuario.Estado = "Activo";
            UsuarioItemFromDb.FechaMod = UsuarioItemVm.Usuario.FechaMod = DateTime.Now;
            UsuarioItemFromDb.UsuarioMod = UsuarioItemVm.Usuario.UsuarioMod = "Admin";

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsuarioItemVm.Usuario = await _db.Usuario.Include(m => m.Departamento).Include(m => m.AreaTrabajo).Include(m => m.Puesto).SingleOrDefaultAsync(m => m.Id == id);

            if (UsuarioItemVm.Usuario == null)
            {
                return NotFound();
            }
            return View(UsuarioItemVm);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _db.Usuario.SingleOrDefaultAsync(m => m.Id == id);
            _db.Usuario.Remove(usuario);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
