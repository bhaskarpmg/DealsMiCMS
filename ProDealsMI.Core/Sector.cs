using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDealsMI.Core
{
    public class Sector
    {
        [Required]
        public int Id { get; set; }

        public string SectorName { get; set; }

        public int OldId { get; set; }

    }
}
