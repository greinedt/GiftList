using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftList.DATA.Entities
{
    public class List
    {
        public int listId { get; set; }
        public int personFK { get; set; }
        public string listName { get; set; }
        public bool isPrivate { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonKey { get; set; }
    }
}
