using _2014140143_ENT.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class Plan
    {

        public int PlanId { get; set; }

        public string codigoPlan { get; set; }
        public string topeConsumo { get; set; }
        public double cargoFijo { get; set; }
        public string caracteristicaPlan { get; set; }

        public TipoPlan TipoPlans { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }

        public Plan()
        {
            TipoPlans = new TipoPlan();
        }

    }
}
