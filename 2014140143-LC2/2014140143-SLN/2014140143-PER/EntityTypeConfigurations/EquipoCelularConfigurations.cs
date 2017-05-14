using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class EquipoCelularConfigurations : EntityTypeConfiguration<EquipoCelular>
    {
        public EquipoCelularConfigurations()
        {
            //Table Configuration
            ToTable("EquipoCelular");
            HasKey(ec => ec.EquipoCelularId);

            //Relationships Configurations


        }
    }
}
