﻿using _2014140143_ENT.Entities;
using _2014140143_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER.Repositories
{
   public  class TrabajadorRepository : Repository<Trabajador>, ITrabajadorRepository
    {
        public TrabajadorRepository(_2014140143DbContext context) : base(context)
        {
        }
    }
}
