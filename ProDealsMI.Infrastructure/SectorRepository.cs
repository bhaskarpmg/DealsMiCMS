using ProDealsMI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDealsMI.Infrastructure
{
    public class SectorRepository : ISectorRepository
    {
        DatabaseContext databaseContext = new DatabaseContext();

        public void Add(Sector obj)
        {
            databaseContext.Sectors.Add(obj);
        }

        public void Edit(Sector obj)
        {
            databaseContext.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public Sector FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sector> GetSectors()
        {
            return databaseContext.Sectors.Select(x => x);
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
