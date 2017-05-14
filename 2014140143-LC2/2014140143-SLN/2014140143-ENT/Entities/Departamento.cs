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

        private List<Provincia> _Provincia;
        int _codDepartamento;
        String _nomDepartamento;
        public Departamento(int codProvincia, int codDepartamento, String nomDepartamento)
        {
            _codDepartamento = codDepartamento;
            _nomDepartamento = nomDepartamento;

            _Provincia = new List<Provincia>(codProvincia);
        }
        public int CodigoDepartamento
        {
            get { return _codDepartamento; }
            set { _codDepartamento = value; }
        }
        public String NombreDepartamento
        {
            get { return _nomDepartamento; }
            set { _nomDepartamento = value; }
        }
        public Provincia CodProvincia { get; set; }
    }
}
