using _2014140143_ENT.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class Venta
    {

        public int VentaId { get; set; }

        public string numeroVenta { get; set; }
        public string modalidadVenta { get; set; }
        public DateTime fechaVenta { get; set; }
        public double montoVenta { get; set; }


        public Evaluacion Evaluacion { get; set; }
        //public int EvaluacionId { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }
        //public int LineaTelefonicaId { get; set; }

        public Contrato Contrato { get; set; }
        // public int ContratoId { get; set; }

        public CentroAtencion CentroAtencion { get; set; }
        //public int  CentroAtencionId { get; set; }

        public Cliente Cliente { get; set; }
        //public int ClienteId { get; set; }

        public TipoPago TipoPago { get; set; }


        public Venta()
        {
            Evaluacion = new Evaluacion();
            LineaTelefonica = new LineaTelefonica();
            Contrato = new Contrato();
            TipoPago = new TipoPago();
        }
        public Venta(Cliente cliente)
        {
            Cliente = cliente;
        }

    }
}
