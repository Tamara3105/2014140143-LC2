using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class EquipoCelular
    {

        public int EquipoCelularId { get; set; }

        public string marcaEquipo { get; set; }
        public string modeloEquipo { get; set; }
        public string colorEquipo { get; set; }
        public string imei { get; set; }
        public double precio { get; set; }
        public ICollection<AdministradorEquipo> AdministradorEquipo { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }
    }
}
