using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.Modelos
    
{
    //Asociar/ ayuda a realizar validaciones o reglas de propiedades de una clase
    //sin modificar el original
    [MetadataType(typeof(MedicoMetadato))]
    public partial class Medico
    {
    }

    public class MedicoMetadato
    {
        [Required]
        [StringLength(10)]
        public string cedula { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string apellidoPaterno { get; set; }
        [StringLength(50)]
        public string apellidoMaterno { get; set; }
        [Required]
        public bool esEspecialista { get; set; }
        [Required]
        public bool habilitado { get; set; }
    }
}
