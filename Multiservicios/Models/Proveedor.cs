using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Proveedor
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = ("Proveedor"))]
        public string NombreProveedor { get; set; }
        public string NombreContacto { get; set; }

        public string CorreoContacto { get; set; }

        public string TelefonoContacto { get; set; }

        public string Estado { get; set; }

        //public DateTime FechaCreacion { get; set; }

        //public String UsuarioCreacion { get; set; }


        //public DateTime FechaModificacion { get; set; }

        //public string UsuarioModificacion { get; set; }
    }
}
