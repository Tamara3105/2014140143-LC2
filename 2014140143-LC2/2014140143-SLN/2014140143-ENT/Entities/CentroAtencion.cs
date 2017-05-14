using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class CentroAtencion
    {
        public int CentroAtencionId { get; set; }

        private List<Direccion> _Direccion;
        int _codCentroAtencion;
        String _nomCentroAtencion;
        public CentroAtencion(int codDireccion, int codCentroAtencion, String nomCentroAtencion)
        {
            _Direccion = new List<Direccion>(codDireccion);

            _codCentroAtencion = codCentroAtencion;
            _nomCentroAtencion = nomCentroAtencion;
        }
        public int CodigoCentroAtencion
        {
            get { return _codCentroAtencion; }
            set { _codCentroAtencion = value; }
        }
        public String NombreCentroAtencion
        {
            get { return _nomCentroAtencion; }
            set { _nomCentroAtencion = value; }
        }
        public int CodDireccion { get; set; }
    }
}
