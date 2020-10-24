using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class TipoSolicitud
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DESCRIPCION { get; set; }
    }
}





