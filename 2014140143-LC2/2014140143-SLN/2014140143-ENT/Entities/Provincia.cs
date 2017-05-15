using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class Provincia
    {
        public int ProvinciaId { get; set; }

        public string Name { get; set; }

        public List<Ubigeo> Ubigeos { get; set; }

        public Provincia()
        {
            Ubigeos = new List<Ubigeo>();
        }


    }
}
