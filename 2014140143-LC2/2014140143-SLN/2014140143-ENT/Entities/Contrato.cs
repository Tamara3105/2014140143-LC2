using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class Contrato
    {
        public int ContratoId { get; set; }

        int _NumeroContrato;
        String _Plazo;
        String _FormaContrato;
        public int NumeroContrato
        {
            get { return _NumeroContrato; }
            set { _NumeroContrato = value; }
        }
        public String Plazo
        {
            get { return _Plazo; }
            set { _Plazo = value; }
        }
        public String FormaContrato
        {
            get { return _FormaContrato; }
            set { _FormaContrato = value; }
        }
        public Contrato(int numContrato, String plazo, String formaContrato)
        {
            NumeroContrato = numContrato;
            Plazo = plazo;
            FormaContrato = formaContrato;

        }
    }
}
