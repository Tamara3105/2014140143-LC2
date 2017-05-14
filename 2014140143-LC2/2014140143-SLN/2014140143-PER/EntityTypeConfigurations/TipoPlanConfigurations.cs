using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class TipoPlanConfigurations : EntityTypeConfiguration<TipoPlan>
    {
        public TipoPlanConfigurations()
        {
            //Table Configuration
            ToTable("TipoPlan");
            HasKey(tp => tp.TipoPlanId);

            //Relationships Configurations


        }
    }
}
