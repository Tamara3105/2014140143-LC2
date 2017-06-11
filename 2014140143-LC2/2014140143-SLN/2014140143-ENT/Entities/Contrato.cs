using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class Contrato
    {

        public int ContratoId { get; set; }

        public long numeroContrato { get; set; }
        public string plazoContrato { get; set; }
        public string formaContrato { get; set; }

        public ICollection<Venta> Venta { get; set; }

    }
}
