using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class AdministradorEquipo
    {
        public int AdministradorEquipoId { get; set; }

        public string modalidad { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public string stockDisponible { get; set; }

        public EquipoCelular EquipoCelulars { get; set; }
        public int EquipoCelularId { get; set; }

        public AdministradorEquipo()
        {
            EquipoCelulars = new EquipoCelular();
        }
    }
}
