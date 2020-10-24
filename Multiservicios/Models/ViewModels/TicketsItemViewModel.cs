using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class TicketsItemViewModel
    {
        public Tickets Tickets { get; set; }
        public IEnumerable<Activo> Activo { get; set; }
        public IEnumerable<TipoSolicitud> TipoSolicitud { get; set; }
    }
}
