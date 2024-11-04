﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.Modelos
{
    [MetadataType(typeof(EgresoMetadato))]
     public partial class Egreso
    {
    }

    public class EgresoMetadato
    {
        [Required]
        public System.DateTime fecha { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal monto { get; set; }
        [Required]
        public long medicold { get; set; }
        [Required]
        public long ingresoId { get; set; }


    }
}
