using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class Distrito
    {
        public int DistritoId { get; set; }

        public string codigoDistrito { get; set; }
        public string nombreDistrito { get; set; }
        public ICollection<Provincia> Provincia { get; set; }
        public ICollection<Ubigeo> Ubigeo { get; set; }
    }
}
