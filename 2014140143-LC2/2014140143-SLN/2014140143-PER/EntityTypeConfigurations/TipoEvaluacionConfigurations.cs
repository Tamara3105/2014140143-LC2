using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class TipoEvaluacionConfigurations : EntityTypeConfiguration<TipoEvaluacion>
    {
        public TipoEvaluacionConfigurations()
        {
            //Table Configuration
            ToTable("TipoEvaluacion");
            HasKey(te => te.TipoEvaluacionId);

            //Relationships Configurations


        }
    }
}
