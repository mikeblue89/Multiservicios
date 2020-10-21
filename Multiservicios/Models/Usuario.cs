using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Correo no valido")]
        public string Correo { get; set; }
        public string Role { get; set; }
        public string Estado { get; set; }

        [Display(Name = "Puesto")]
        public int PuestoId { get; set; }

        [ForeignKey("PuestoId")]
        public virtual Puesto Puesto { get; set; }

        [Display(Name = "Area")]
        public int AreaTrabajoId { get; set; }

        [ForeignKey("AreaTrabajoId")]
        public virtual AreaTrabajo AreaTrabajo { get; set; }

        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }

        public string Password { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioMod { get; set; }

    }
}
