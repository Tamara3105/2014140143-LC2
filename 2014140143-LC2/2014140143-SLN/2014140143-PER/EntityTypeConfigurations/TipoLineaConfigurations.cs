using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class TipoLineaConfigurations : EntityTypeConfiguration<TipoLinea>
    {
        public TipoLineaConfigurations()
        {
            //Table Configuration
            ToTable("TipoLinea");
            HasKey(tl => tl.TipoLineaId);

            //Relationships Configurations


        }
    }
}
