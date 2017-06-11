using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public  class Departamento
    {
        public int DepartamentoId { get; set; }

        public string codigoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }

        public Provincia Provincias { get; set; }
        //public int ProvinciaId { get; set; }
        public ICollection<Ubigeo> Ubigeo { get; set; }

        public Departamento()
        {
            Provincias = new Provincia();
        }

    }
}
