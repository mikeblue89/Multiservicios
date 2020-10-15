using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Activo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public DateTime Fecha_Adquisicion { get; set; }
        public string No_ { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marca Marca { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
        [Display(Name = "Imagen")]
        public string RutaFoto { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Motivo de Baja")]
        public string Motivo_Baja { get; set; }
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        [ForeignKey("ProveedorId")]
        public virtual Proveedor Proveedor { get; set; }

        [Display(Name = "Fecha de Creacion")]
        public DateTime Fecha_Creacion { get; set; }
        [Display(Name = "Usuario de Creacion")]
        public string Usuario_Creacion { get; set; }
        [Display(Name = "Fecha de Modificacion")]
        public DateTime Fecha_Modificacion { get; set; }
        [Display(Name = "Usuario de Modificacion")]
        public string Usuario_Modificacion { get; set; }
    }
}
