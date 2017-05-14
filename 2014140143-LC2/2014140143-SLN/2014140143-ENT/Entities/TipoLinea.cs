using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class TipoLinea
    {
        public int TipoLineaId { get; set; }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public TipoLinea(string descripcion)
        {
            Descripcion = descripcion;
        }
        public TipoLinea()
        {
            Descripcion = "";
        }

    }
}
