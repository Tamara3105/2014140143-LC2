using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class EstadoEvaluacion
    {
        public int EstadoEvaluacionId { get; set; }

        public string Estado { get; set; }
        public EstadoEvaluacion()
        {

        }
        public EstadoEvaluacion(string estado)
        {
            Estado = estado;
        }

    }
}
