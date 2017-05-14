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

        private List<EquipoCelular> _Equipos;

        public AdministradorEquipo()
        {
            Equipos = new List<EquipoCelular>();
        }

        public List<EquipoCelular> Equipos
        {
            get { return _Equipos; }
            private set { _Equipos = value; }
        }

        public void AgregarEquipo(EquipoCelular equipo)
        {
            Equipos.Add(equipo);
        }
    }
}
