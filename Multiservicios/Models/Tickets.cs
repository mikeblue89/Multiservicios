using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Multiservicios.Models
{
    public class Tickets
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Activo")]
        public int ID_ACTIVO { get; set; }

        [ForeignKey("ID_ACTIVO")]
        public virtual Activo Activo { get; set; }


       [Display(Name = "TipoSolicitud")]
       public int ID_TIPO_SOLICITUD { get; set; }
       
       [ForeignKey("ID_TIPO_SOLICITUD")]
       public virtual TipoSolicitud TipoSolicitud { get; set; }

        public string NO_SERIE { get; set; }
        public int USUARIO_ASIGNACION { get; set; }
        public int ID_ACTIVIDAD { get; set; }
        public string DESCRIPCION { get; set; }
        public int ID_PROCESO { get; set; }
        public string ESTADO { get; set; }
        public string FECHA_CREACION { get; set; }
        public int USUARIO_CREACION { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public int USUARIO_MODIFICACION { get; set; }
    }
}
