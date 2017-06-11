using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class Direccion
    {
        public int DireccionId { get; set; }

        public string codigoDireccion { get; set; }
        public string descripcionDireccion { get; set; }

        public Ubigeo Ubigeos { get; set; }
        public int UbigeoId { get; set; }
        public CentroAtencion CentroAtencion { get; set; }

        public Direccion()
        {
            Ubigeos = new Ubigeo();
        }
    }
}
