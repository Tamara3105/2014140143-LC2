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

        int _codVenta;
        String _modalidad;
        String _fechaVanta;
        Double _montoTotal;

        private List<LineaTelefonica> _LineaTelefonica;
        private List<Contrato> _Contrato;
        private List<Evaluacion> _Evaluacion;
        private List<Cliente> _Cliente;
        private TipoPago _TipoPago;
        public Venta()
        {
            _LineaTelefonica = new List<LineaTelefonica>();
            _Contrato = new List<Contrato>();
            _Evaluacion = new List<Evaluacion>();
            _Cliente = new List<Cliente>();
        }
        public Venta(int codVenta, String modalidad, String fechaVanta, Double montoTotal, TipoPago tipoPago)
        {
            CodigoVenta = codVenta;
            Modalidad = modalidad;
            FechaVanta = fechaVanta;
            MontoTotal = montoTotal;
            TiposPagos = tipoPago;
        }
        public int CodigoVenta
        {
            get { return _codVenta; }
            set { _codVenta = value; }
        }
        public String Modalidad
        {
            get { return _modalidad; }
            set { _modalidad = value; }
        }
        public String FechaVanta
        {
            get { return _fechaVanta; }
            set { _fechaVanta = value; }
        }
        public Double MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }
        public TipoPago TiposPagos
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }



    }
}
