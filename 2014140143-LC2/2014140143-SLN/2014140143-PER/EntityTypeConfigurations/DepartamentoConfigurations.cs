using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class DepartamentoConfigurations : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfigurations()
        {
            //Table Configuration
            ToTable("Departamento");
            HasKey(dp => dp.DepartamentoId);

            //Relationships Configurations


        }
    }
}
