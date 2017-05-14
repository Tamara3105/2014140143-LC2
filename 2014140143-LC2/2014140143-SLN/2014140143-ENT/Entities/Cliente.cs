using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        int _codigoClie;
        String _nombreClie;
        String _apePaternoClie;
        String _apeMaternoClie;
        String _dniClie;
        String _fecNacimientoClie;
        Double _sueldoClie;
        String _correoClie;
        String _direccionClie;

        public Cliente(int codigoCli, String nombreClie, String apePaternoClie, String apeMaternoClie, String dniClie, String fecNacimientoClie, Double sueldoClie, String correoClie, String direccionClie)
        {
            _codigoClie = codigoCli;
            _nombreClie = nombreClie;
            _apePaternoClie = apePaternoClie;
            _apeMaternoClie = apeMaternoClie;
            _dniClie = dniClie;
            _fecNacimientoClie = fecNacimientoClie;
            _sueldoClie = sueldoClie;
            _correoClie = correoClie;
            _direccionClie = direccionClie;
        }
        public int CodigoCliente
        {
            get { return _codigoClie; }
            set { _codigoClie = value; }
        }
        public String NombreCliente
        {
            get { return _nombreClie; }
            set { _nombreClie = value; }
        }
        public String ApePaternoCliente
        {
            get { return _apePaternoClie; }
            set { _apePaternoClie = value; }
        }
        public String ApeMaternoCliente
        {
            get { return _apeMaternoClie; }
            set { _apeMaternoClie = value; }
        }
        public String DNICliente
        {
            get { return _dniClie; }
            set { _dniClie = value; }
        }
        public String FecNacimientoCliente
        {
            get { return _fecNacimientoClie; }
            set { _fecNacimientoClie = value; }
        }
        public Double SueldoCliente
        {
            get { return _sueldoClie; }
            set { _sueldoClie = value; }
        }
        public String CorreoCliente
        {
            get { return _correoClie; }
            set { _correoClie = value; }
        }
        public String DireccionCliente
        {
            get { return _direccionClie; }
            set { _direccionClie = value; }
        }

    }
}
