using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
    public class AdministradorLinea
    {
        public int AdministradorLineaId { get; set; }

        public int numeroTelefonico { get; set; }
        public DateTime fecha { get; set; }
        public string estadoLinea { get; set; }

        public LineaTelefonica LineaTelefonicas { get; set; }
        public int LineaTelefonicaId { get; set; }

        public AdministradorLinea()
        {
            LineaTelefonicas = new LineaTelefonica();
        }

    }
}
