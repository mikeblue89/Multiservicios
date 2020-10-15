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

namespace Multiservicios.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class ActivoController : Controller
    {

        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public ActivoItemViewModel ActivoItemVm { get; set; }

        public ActivoController(ApplicationDbContext db)
        {
            _db = db;
            ActivoItemVm = new ActivoItemViewModel()
            {
                Categoria = _db.Categoria,
                Marca = _db.Marca,
                Proveedor = _db.Proveedor,
                Activo = new Models.Activo()
            };
        }

        // GET INDEX
        public async Task<IActionResult> Index()
        {
            var activoItems = await _db.Activo.Include(s => s.Marca).Include(s => s.Categoria).Include(s => s.Proveedor).ToListAsync();
            return View(activoItems);
        }

        //GET CREAR
        public IActionResult Create()
        {               
            return View(ActivoItemVm);
        }

        //POST - CREAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activo_Categoria_Marca_ProveedorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesActivoExists = _db.Activo.Include(s => s.Marca).Include(s => s.Categoria).Include(s => s.Proveedor).Where(s => s.Nombre == model.Activo.Nombre && s.Marca.Id == model.Activo.MarcaId && s.Categoria.Id == model.Activo.CategoriaId && s.Proveedor.Id == model.Activo.ProveedorId);
                if (doesActivoExists.Count() > 0)
                {
                    //Error
                    //////////////////////////
                    StatusMessage = "Error: La marca: " + doesActivoExists.First().Marca.Nombre + " ya existe, ingrese una marca diferente";
                    StatusMessage = "Error: La categoria: " + doesActivoExists.First().Categoria.Nombre + " ya existe, ingrese una categoria diferente";
                    StatusMessage = "Error: El proveedor: " + doesActivoExists.First().Proveedor.Nombre + " ya existe, ingrese un proveedor diferente";
                }
                else
                {
                    _db.Activo.Add(model.Activo);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            Activo_Categoria_Marca_ProveedorViewModel modelVm = new Activo_Categoria_Marca_ProveedorViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                MarcaList = await _db.Marca.ToListAsync(),
                ProveedorList = await _db.Proveedor.ToListAsync(),
                Activo = model.Activo,
                ActivoList = await _db.Activo.OrderBy(p => p.Nombre).Select(p => p.Nombre).ToListAsync(),
                StatusMessage = StatusMessage

            };
            return View(modelVm);
        }
        
                

        //GET - EDITAR
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            ActivoItemVm.Activo = await _db.Activo.Include(m => m.Categoria).Include(m => m.Marca).Include(m => m.Proveedor).SingleOrDefaultAsync(m => m.Id == id);

            if (ActivoItemVm == null)
            {
                return NotFound();
            }

            return View(ActivoItemVm);

        }


        //POST - EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoItemFromDb = await _db.Activo.FindAsync(ActivoItemVm.Activo.Id);
            activoItemFromDb.Nombre = ActivoItemVm.Activo.Nombre;
            activoItemFromDb.Cantidad = ActivoItemVm.Activo.Cantidad;
            activoItemFromDb.Fecha_Adquisicion = ActivoItemVm.Activo.Fecha_Adquisicion;
            activoItemFromDb.No_ = ActivoItemVm.Activo.No_;
            activoItemFromDb.MarcaId = ActivoItemVm.Activo.MarcaId;
            activoItemFromDb.CategoriaId = ActivoItemVm.Activo.CategoriaId;
            activoItemFromDb.RutaFoto = ActivoItemVm.Activo.RutaFoto;
            activoItemFromDb.Estado = ActivoItemVm.Activo.Estado;
            activoItemFromDb.Motivo_Baja = ActivoItemVm.Activo.Motivo_Baja;
            activoItemFromDb.Descripcion = ActivoItemVm.Activo.Descripcion;
            activoItemFromDb.ProveedorId = ActivoItemVm.Activo.ProveedorId;
            activoItemFromDb.Fecha_Modificacion = ActivoItemVm.Activo.Fecha_Modificacion;
            activoItemFromDb.Usuario_Modificacion = ActivoItemVm.Activo.Usuario_Modificacion;

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

            var activo = await _db.Activo.SingleOrDefaultAsync(m => m.Id == id);

            if (activo == null)
            {
                return NotFound();
            }
           
            Activo_Categoria_Marca_ProveedorViewModel model = new Activo_Categoria_Marca_ProveedorViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                MarcaList = await _db.Marca.ToListAsync(),
                ProveedorList = await _db.Proveedor.ToListAsync(),
                Activo = activo,
                ActivoList = await _db.Activo.OrderBy(p => p.Nombre).Select(p => p.Nombre).ToListAsync(),                
            };

            return View(model);

        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activo = await _db.Activo.SingleOrDefaultAsync(m => m.Id == id);
            _db.Activo.Remove(activo);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
