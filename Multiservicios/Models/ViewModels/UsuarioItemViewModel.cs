using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class UsuarioItemViewModel
    {
        public Usuario Usuario { get; set; }
        public IEnumerable<Departamento> Departamento { get; set; }
        public IEnumerable<AreaTrabajo> AreaTrabajo { get; set; }
        public IEnumerable<Puesto> Puesto { get; set; }
    }
}
