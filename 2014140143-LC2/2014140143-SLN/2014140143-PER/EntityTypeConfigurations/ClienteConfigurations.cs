using _2014140143_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.EntityTypeConfigurations
{
    public class ClienteConfigurations : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfigurations()
        {
            //Table Configuration
            ToTable("Cliente");
            HasKey(cl => cl.ClienteId);

            //Relationships Configurations


        }
    }
}
