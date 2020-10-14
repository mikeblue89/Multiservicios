using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Puesto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nombre de Puesto")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //Departamento
        [Display(Name ="Departamento De Trabajo")]
        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }
        //Area
        [Display(Name = "Area De Trabajo")]
        public int AreaTrabajoId { get; set; }
        [ForeignKey("AreaTrabajoId")]
        public virtual AreaTrabajo AreaTrabajo { get; set; }
    }
}
