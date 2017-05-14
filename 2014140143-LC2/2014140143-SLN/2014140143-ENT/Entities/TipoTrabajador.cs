using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class TipoTrabajador
    {
        public int TipoTrabajadorId { get; set; }

        int _codTipoTrabajador;
        String _tipoTrabajador;

        public TipoTrabajador(int codTipoTrabajador, String tipoTrabajador)
        {
            _codTipoTrabajador = codTipoTrabajador;
            _tipoTrabajador = tipoTrabajador;
        }
        public int CodigoTipoTrabajor
        {
            get { return _codTipoTrabajador; }
            set { _codTipoTrabajador = value; }
        }
        public String DescripTipoTrabajador
        {
            get { return _tipoTrabajador; }
            set { _tipoTrabajador = value; }
        }
    }
}
