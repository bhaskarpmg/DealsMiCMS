using ProDealsMI.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDealsMI.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base ("name=DBConnectionString")
        {

        }

        public DbSet<Sector> Sectors { get; set; }

    }
}
