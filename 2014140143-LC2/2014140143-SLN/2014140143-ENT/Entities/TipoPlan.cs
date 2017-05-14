using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class TipoPlan
    {
        
        public int TipoPlanId { get; set; }
        public string DescripcionTipoPlan { get; set; }
        public TipoPlan()
        {

        }
        public TipoPlan(string descripcionTipoPlan)
        {
            DescripcionTipoPlan = descripcionTipoPlan;
        }

    }
}
