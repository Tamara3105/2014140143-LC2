using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
  public  class Trabajador
    {
        public int TrabajadorId { get; set; }

        int _codTrabajador;
        String _nomTrabajador;
        String _apePaTrabajador;
        String _apMaTrabajador;

        private List<TipoTrabajador> _TipoTrabajador;
        public Trabajador(int codTrabajador, String nomTrabajador, String apePaTrabajador, String apMaTrabajador, int numTipoTrabajador)
        {
            _codTrabajador = codTrabajador;
            _nomTrabajador = nomTrabajador;
            _apePaTrabajador = apePaTrabajador;
            _apMaTrabajador = apMaTrabajador;

            _TipoTrabajador = new List<TipoTrabajador>(numTipoTrabajador);
        }
        public int CodigoTrabajador
        {
            get { return _codTrabajador; }
            set { _codTrabajador = value; }
        }
        public String NombreTrabajador
        {
            get { return _nomTrabajador; }
            set { _nomTrabajador = value; }
        }
        public String ApellidoPaTrabajador
        {
            get { return _apePaTrabajador; }
            set { _apePaTrabajador = value; }
        }
        public String ApellidoMaTrabajador
        {
            get { return _apMaTrabajador; }
            set { _apMaTrabajador = value; }
        }
        public int NumtipoTrabajador { get; set; }

    }
}
