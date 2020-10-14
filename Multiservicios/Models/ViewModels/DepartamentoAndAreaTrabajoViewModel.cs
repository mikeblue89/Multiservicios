using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class DepartamentoAndAreaTrabajoViewModel
    {
        public IEnumerable<Departamento> DepartamentoList { get; set;}
        public AreaTrabajo AreaTrabajo { get; set; }

        public List<string> AreaTrabajoList { get; set; }
        public string StatusMessage { get; set; }

    }
}
