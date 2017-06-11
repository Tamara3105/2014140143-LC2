using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class AdministradorLineaConfigurations : EntityTypeConfiguration<AdministradorLinea>
    {
        public AdministradorLineaConfigurations()
        {
            //Table Configuration
            ToTable("AdministrarLinea");
            HasKey(al => al.AdministradorLineaId);

            //Relationships Configurations
            HasRequired(lt => lt.LineaTelefonicas).WithMany(al => al.AdministradorLinea).HasForeignKey(lt => lt.LineaTelefonicaId);

        }
    }
}
