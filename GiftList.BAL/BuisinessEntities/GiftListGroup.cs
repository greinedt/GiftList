using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.DATA.Entities
{
    public class GiftListGroup
    {
        public int giftListGroupId { get; set; }
        public int giftListFK { get; set; }
        public int groupFK { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonFK { get; set; }
    }
}
