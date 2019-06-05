using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDealsMI.Infrastructure
{
    public class InitializeDatabase : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {

    }
}
