using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftList.DATA.Entities
{
    public class Item
    {
        public int itemId { get; set; }
        public int itemStatusFK { get; set; }
        public int listFK { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonFK { get; set; }
    }
}
