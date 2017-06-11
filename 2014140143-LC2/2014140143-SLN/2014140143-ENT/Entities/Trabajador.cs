using _2014140143_ENT.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
  public  class Trabajador
    {

        public int TrabajadorId { get; set; }

        public string codigoTrabajador { get; set; }
        public string nombreTrabajador { get; set; }
        public string apPaternoTrabajador { get; set; }
        public string apMaternoTrabajador { get; set; }
        public string dniTrabajador { get; set; }

        public TipoTrabajador TipoTrabajadors { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }

        //public byte TipoTrabajadorId { get; set; }

        //public ICollection<Evaluacion> Evaluacion { get; set; }

        public Trabajador()
        {
            TipoTrabajadors = new TipoTrabajador();
        }
    }
}
