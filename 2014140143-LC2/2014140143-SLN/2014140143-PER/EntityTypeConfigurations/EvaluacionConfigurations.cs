using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class EvaluacionConfigurations : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfigurations()
        {
            //Table Configuration
            ToTable("Evaluacion");
            HasKey(eva => eva.EvaluacionId);

            //Relationships Configurations
            HasRequired(pl => pl.Plans).WithMany(ev => ev.Evaluacion);//.HasForeignKey(pl => pl.PlanId);
            HasRequired(ec => ec.EquipoCelular).WithMany(ev => ev.Evaluacion);//.HasForeignKey(ec => ec.EquipoCelularId);
            HasRequired(lt => lt.LineaTelefonica).WithMany(ev => ev.Evaluacion);//.HasForeignKey(lt => lt.LineaTelefonicaId);
            HasRequired(ca => ca.CentroAtencion).WithRequiredPrincipal(ca => ca.Evaluacion);
            HasRequired(tb => tb.Trabajador).WithMany(ev => ev.Evaluacion);//.HasForeignKey(tb => tb.TrabajadorId);
            HasRequired(cl => cl.Cliente).WithMany(ev => ev.Evaluacion);//.HasForeignKey(cl => cl.ClienteId);

        }
    }
}
