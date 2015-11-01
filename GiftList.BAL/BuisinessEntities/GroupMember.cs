using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.DATA.Entities
{
    public class GroupMember
    {
        public int groupMemberId { get; set; }
        public int groupFK { get; set; }
        public int memberFK { get; set; }
        public bool isAdmin { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonFK { get; set; }
    }
}
