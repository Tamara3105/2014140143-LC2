using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class AdministradorEquipoConfigurations : EntityTypeConfiguration<AdministradorEquipo>
    {
        public AdministradorEquipoConfigurations()
        {
            //Table Configuration
            ToTable("AdministradorEquipo");
            HasKey(ae => ae.AdministradorEquipoId);

            //Relationships Configurations
            HasRequired(ec => ec.EquipoCelulars).WithMany(ae => ae.AdministradorEquipo).HasForeignKey(ec => ec.EquipoCelularId);

        }
    }
   
}
