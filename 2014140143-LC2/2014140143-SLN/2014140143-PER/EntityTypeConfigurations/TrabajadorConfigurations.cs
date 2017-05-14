using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class TrabajadorConfigurations : EntityTypeConfiguration<Trabajador>
    {
        public TrabajadorConfigurations()
        {
            //Table Configuration
            ToTable("Trabajador");
            HasKey(tr => tr.TrabajadorId);

            //Relationships Configurations


        }
    }
}
