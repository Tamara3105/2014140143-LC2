using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class LineaTelefonica
    {
        public int LineaTelefonicaId { get; set; }

        String _numeroTelefonico;
        String _icciaTelefonico;

        private TipoLinea _TipoLinea;
        private string numero;
        public LineaTelefonica()
        {
            TipoLinea = new TipoLinea();
        }
        public LineaTelefonica(String numeroTelefonico, String icciaTelefonico)
        {
            IcciaTelefonico = icciaTelefonico;
        }

        public LineaTelefonica(string numeroTelefonico)
        {
            NumeroTelefonico = numeroTelefonico;
            TipoLinea = AsignarTipo(numeroTelefonico);
        }
        public TipoLinea TipoLinea
        {
            get { return _TipoLinea; }
            set { _TipoLinea = value; }
        }
        public String NumeroTelefonico
        {
            get { return _numeroTelefonico; }
            set { _numeroTelefonico = value; }
        }
        public String IcciaTelefonico
        {
            get { return _icciaTelefonico; }
            set { _icciaTelefonico = value; }
        }
        public TipoLinea AsignarTipo(string numero)
        {
            if (numero[0] == '9')
                return new TipoLinea("Fijo");
            else
                return new TipoLinea("Celular");
        }

    }
}
