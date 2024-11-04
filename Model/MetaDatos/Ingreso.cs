using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.Modelos
{
    [MetadataType(typeof(IngresoMetadato))]
    public partial class Ingreso
    {
    }

    public class IngresoMetadato
    {
        [Required]
        public System.DateTime fecha { get; set; }
        [Required]
        public int numeroSala { get; set; }
        [Required]
        public int numeroCama { get; set; }
        [Required]
        [StringLength(500)]
        public string diagnostico { get; set; }
        [Required]
        public long medicold { get; set; }
        [Required]
        public long pacienteId { get; set; }

    }
}
