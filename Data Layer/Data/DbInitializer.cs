using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Data
{
    internal class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
    }
}
