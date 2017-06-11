using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class CentroAtencionConfigurations : EntityTypeConfiguration<CentroAtencion>
    {
        public CentroAtencionConfigurations()
        {
            //Table Configuration
            ToTable("CentroAtencion");
            HasKey(ca => ca.CentroAtencionId);

            //Relationships Configurations
            HasRequired(di => di.Direccions).WithRequiredPrincipal(di => di.CentroAtencion);

        }
    }
}
