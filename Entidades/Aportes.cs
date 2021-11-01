﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class Aportes
    {
        //AporteId,Fecha,PersonaId,Concepto, Monto
        [Key]
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int PersonaId { get; set; }
        public string Concepto { get; set; }
        public float Monto { get; set; }
        public int AporteDetalleId { get; set; }

        [ForeignKey("PersonaId")]
        public virtual Personas Persona { get; set; }

        [ForeignKey("AporteDetalleId")]
        public List<AportesDetalle> AporteDetalle { get; set; } = new List<AportesDetalle>();
       
    }
}
