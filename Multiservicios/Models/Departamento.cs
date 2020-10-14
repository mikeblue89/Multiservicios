using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nombre de Departamento")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //public String Estado { get; set; }
        //public int UsuarioCreacion { get; set; }
        //public DateTime FechaCreacion { get; set; }
        // public DateTime FechaModificacion { set; get; }
    }
}
