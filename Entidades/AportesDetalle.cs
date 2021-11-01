using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class AportesDetalle
    {
        [Key]
        public int AporteDetalleId { get; set; }
        public int TipoAporteId { get; set; }
        public float Valor { get; set; }
        public Personas Persona { get; set; }

        public AportesDetalle()
        {
            AporteDetalleId = 0;
            TipoAporteId = 0;
            Valor = 0;
            Persona = null;
            Aporte = null;
        }
        public AportesDetalle(int TipoAporteId, float Valor, Personas Persona, TiposAportes Aporte)
        {
            AporteDetalleId = 0;
            this.TipoAporteId = TipoAporteId;
            this.Valor = Valor;
            this.Persona = Persona;
            this.Aporte = Aporte;
        }
         
        [ForeignKey("TipoAporteId")]
        public TiposAportes Aporte { get; set; }
    
    }
}
