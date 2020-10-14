using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class PuestoItemViewModel
    {
        public Puesto Puesto { get; set; }
        public IEnumerable<Departamento> Departamento { get; set; }
        public IEnumerable<AreaTrabajo> AreaTrabajo { get; set; }
    }
}
