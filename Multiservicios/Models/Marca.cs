using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Marca
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de Marca")]
        public string Nombre_Marca { get; set; }
        public string Tipo_Activo { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }

    }
}
