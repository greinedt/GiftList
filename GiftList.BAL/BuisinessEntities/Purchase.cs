using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.DATA.Entities
{
    public class Purchase
    {
        public int purchaseId { get; set; }
        public int itemFK { get; set; }
        public int purchaserFK { get; set; }
        public DateTime? purchaseDate { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonFK { get; set; }
    }
}
