using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class AreaTrabajo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name =("Nombre de Area"))]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        [Display(Name ="Departamento")]
        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }
    }
}
