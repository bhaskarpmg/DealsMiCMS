using System;
using System.Collections.Generic;
using ProDealsMI.Core;
using ProDealsMI.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProDealsMI.Test
{
    [TestClass]
    public class SectorRepositoryTest
    {
        SectorRepository Repo;

        [TestInitialize]
        [TestMethod]
        public void TestSetup()
        {
            Repo = new SectorRepository();
        }
        [TestMethod]
        public void IsGetSectorsWorking()
        {
            IEnumerable<Sector> result = Repo.GetSectors();
            Assert.IsNotNull(result);
            //var noofrecords = result.
        }
    }
}
