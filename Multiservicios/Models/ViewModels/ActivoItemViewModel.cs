using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class ActivoItemViewModel
    {
        public Activo Activo { get; set; }
        public IEnumerable<Marca> Marca { get; set; }
        public IEnumerable<Categoria> Categoria { get; set; }
        public IEnumerable<Proveedor> Proveedor { get; set; }
        
    }
}
