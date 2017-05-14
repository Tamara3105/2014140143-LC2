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

        int _codPlan;
        String _topeConsumo;
        String _cargoFijo;
        String _caracteristicaPlan;

        private TipoPlan _TipoPlan;
        public Plan(int codPlan, String topeConsumo, String cargoFijo, String caracteristicaPlan)
        {
            _codPlan = codPlan;
            _topeConsumo = topeConsumo;
            _cargoFijo = cargoFijo;
            _caracteristicaPlan = caracteristicaPlan;

            _TipoPlan = new TipoPlan();
        }
        public int CodigoPlan
        {
            get { return _codPlan; }
            set { _codPlan = value; }
        }
        public String TopeConsumo
        {
            get { return _topeConsumo; }
            set { _topeConsumo = value; }
        }
        public String CargoFijo
        {
            get { return _cargoFijo; }
            set { _cargoFijo = value; }
        }
        public String CaracteristicasPlan
        {
            get { return _caracteristicaPlan; }
            set { _caracteristicaPlan = value; }
        }

    }
}
