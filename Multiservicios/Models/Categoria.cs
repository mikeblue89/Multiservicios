using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de Categoria")]
        public string Nombre_Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public string Usuario_Modificacion { get; set; }
    }
}
