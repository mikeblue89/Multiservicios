using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class Activo_Categoria_Marca_ProveedorViewModel
    {
        public IEnumerable<Marca> MarcaList { get; set; }
        public IEnumerable<Categoria> CategoriaList { get; set; }
        public IEnumerable<Proveedor> ProveedorList { get; set; }
        public Activo Activo { get; set; }
        public List<string> ActivoList { get; set; }
        public string StatusMessage { get; set; }
    }
}
