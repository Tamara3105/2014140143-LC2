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

        public List<LineaTelefonica> Lineas { get; set; }

        public AdministradorLinea()
        {
            Lineas = new List<LineaTelefonica>();
        }

        public void AgregarLinea(string numero)
        {
            Lineas.Add(new LineaTelefonica(numero));
        }
    }
}
