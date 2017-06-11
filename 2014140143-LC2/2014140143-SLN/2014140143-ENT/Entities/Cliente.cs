using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class Cliente
    {

        public int ClienteId { get; set; }

        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string dni { get; set; }
        public double sueldo { get; set; }
        public DateTime fecNacimiento { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public ICollection<Venta> Venta { get; set; }


    }
}
