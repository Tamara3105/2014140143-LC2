using _2014140143_ENT.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class LineaTelefonica
    {

        public int LineaTelefonicaId { get; set; }

        public string codigoLinea { get; set; }
        public string iccid { get; set; }
        public string costoMinuto { get; set; }

        public TipoPlan TipoPlans { get; set; }
        public ICollection<AdministradorLinea> AdministradorLinea { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }
        public ICollection<Venta> Venta { get; set; }
    }
}
