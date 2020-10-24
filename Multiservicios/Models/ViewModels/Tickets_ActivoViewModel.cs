using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models.ViewModels
{
    public class Tickets_ActivoViewModel
    {
        public IEnumerable<Activo> ActivoList { get; set; }
        public IEnumerable<TipoSolicitud> TipoSolicitudList { get; set; }
        public Tickets Tickets { get; set; }
        public List<string> TicketsList { get; set; }
        public string StatusMessage { get; set; }
    }
}
