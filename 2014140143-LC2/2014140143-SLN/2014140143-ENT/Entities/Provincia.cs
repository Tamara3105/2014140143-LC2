using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class Provincia
    {
        public int ProvinciaId { get; set; }

        //public string codigoProvincia { get; set; }
        public string nombreProvincia { get; set; }

        public Distrito Distritos { get; set; }
        //public int DistritoId { get; set; }
        public ICollection<Ubigeo> Ubigeo { get; set; }
        public ICollection<Departamento> Departamento { get; set; }

        //public ICollection<Departamento> Departamento { get; set; }

        public Provincia()
        {
            Distritos = new Distrito();
        }


    }
}
