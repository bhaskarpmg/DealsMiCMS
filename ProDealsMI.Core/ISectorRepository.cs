using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDealsMI.Core
{
    public interface ISectorRepository
    {
        void Add(Sector obj);

        void Edit(Sector obj);

        void Remove(int Id);

        IEnumerable<Sector> GetSectors();

        Sector FindById(int Id);
    }
}
