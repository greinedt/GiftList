using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftList.DATA.Entities
{
    public class ItemStatus
    {
        public int itemStatusId { get; set; }
        public string status { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonKey { get; set; }
    }
}
