using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multiservicios.Data;
using Multiservicios.Models.ViewModels;

namespace Multiservicios.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class SolicitudController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public SolicitudCompraItemViewModel SolicitudItemVm { get; set; }

        public SolicitudController(ApplicationDbContext db)
        {
            _db = db;
            SolicitudItemVm = new SolicitudCompraItemViewModel()
            {
                Categoria = _db.Categoria,
                Marca = _db.Marca,
                SolicitudCompra = new Models.SolicitudCompra()
            };
        }
        //GET Index
        public async Task<IActionResult> Index()
        {
            var SolicitudItems = await _db.SolicitudCompra.Include(m => m.Marca).Include(m => m.Categoria).ToListAsync();

            return View(SolicitudItems);
        }

        //GET CREAR
        public IActionResult Create()
        {
            return View(SolicitudItemVm);
        }

        //POST - CREAR
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
           

            if (!ModelState.IsValid)
            {
                return View(SolicitudItemVm);
            }
            SolicitudItemVm.SolicitudCompra.Estado = "Pendiente";
            SolicitudItemVm.SolicitudCompra.Usuario_Creacion = "Admin";
            SolicitudItemVm.SolicitudCompra.Usuario_Modificacion = "Admin";
            SolicitudItemVm.SolicitudCompra.Fecha_Creacion = DateTime.Now;
            SolicitudItemVm.SolicitudCompra.Fecha_Modificacion = DateTime.Now;

            _db.SolicitudCompra.Add(SolicitudItemVm.SolicitudCompra);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET - EDITAR
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SolicitudItemVm.SolicitudCompra = await _db.SolicitudCompra.Include(m => m.Categoria).Include(m => m.Marca).SingleOrDefaultAsync(m => m.Id == id);

            if (SolicitudItemVm.SolicitudCompra == null)
            {
                return NotFound();
            }
            return View(SolicitudItemVm);
        }

        //POST - EDIT

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
                      

            if (!ModelState.IsValid)
            {
                return View(SolicitudItemVm);
            }

            var SolicitudItemFromDb = await _db.SolicitudCompra.FindAsync(SolicitudItemVm.SolicitudCompra.Id);
            SolicitudItemFromDb.Estado = SolicitudItemVm.SolicitudCompra.Estado = "Notificado";
            SolicitudItemFromDb.Usuario_Modificacion = SolicitudItemVm.SolicitudCompra.Usuario_Modificacion = "Admin";
            SolicitudItemFromDb.Fecha_Modificacion = SolicitudItemVm.SolicitudCompra.Fecha_Modificacion = DateTime.Now;
            SolicitudItemFromDb.Descripcion = SolicitudItemVm.SolicitudCompra.Descripcion;



            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
