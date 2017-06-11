using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class Ubigeo
    {

        public int UbigeoId { get; set; }

        public string codUbigeo { get; set; }

        public Distrito Distritos { get; set; }
        public Provincia Provincias { get; set; }
        public Departamento Departamentos { get; set; }

        //public int DistritoId { get; set; }
        //public int  ProvinciaId { get; set; }
        //public int  DepartamentoId { get; set; }
        public ICollection<Direccion> Direccion { get; set; }

        public Ubigeo()
        {

        }
        public Ubigeo(Distrito distrito, Provincia provincia, Departamento departamento)
        {
            Distritos = distrito;
            Provincias = provincia;
            Departamentos = departamento;
        }

    }
}
