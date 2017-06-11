using _2014140143_ENT.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class Evaluacion
    {

        public int EvaluacionId { get; set; }

        public int numeroEvaluacion { get; set; }
        public string documento { get; set; }
        public DateTime fechaEvaluacion { get; set; }

        public CentroAtencion CentroAtencion { get; set; }
        public Trabajador Trabajador { get; set; }
        //public int TrabajadorId { get; set; }
        public Cliente Cliente { get; set; }
        //public int ClienteId { get; set; }
        public Plan Plans { get; set; }
        // public int PlanId { get; set; }
        public EquipoCelular EquipoCelular { get; set; }
        // public int EquipoCelularId { get; set; }
        public LineaTelefonica LineaTelefonica { get; set; }
        //public int  LineaTelefonicaId { get; set; }

        public EstadoEvaluacion EstadoEvaluacion { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }
        public ICollection<Venta> Venta { get; set; }

        public Evaluacion()
        {
            TipoEvaluacion = new TipoEvaluacion();
            EstadoEvaluacion = new EstadoEvaluacion();
            EquipoCelular = new EquipoCelular();
        }
        public Evaluacion(Plan plan, LineaTelefonica lineaTelefonica, Cliente cliente)
        {
            Plans = plan;
            LineaTelefonica = lineaTelefonica;
            Cliente = cliente;
        }
    }
}
