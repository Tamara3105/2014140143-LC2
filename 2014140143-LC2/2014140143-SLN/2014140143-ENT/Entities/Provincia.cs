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

        private List<Distrito> _Distrito;
        int _codProvincia;
        String _nomProvincia;
        public Provincia(int codDistrito, int codProvincia, String nomProvincia)
        {
            _codProvincia = codDistrito;
            _nomProvincia = nomProvincia;

            _Distrito = new List<Distrito>(codDistrito);
        }
        public int CodigoProvincia
        {
            get { return _codProvincia; }
            set { _codProvincia = value; }
        }
        public String NombreProvincia
        {
            get { return _nomProvincia; }
            set { _nomProvincia = value; }
        }
        public Distrito CodigoDistrito { get; set; }

    }
}
