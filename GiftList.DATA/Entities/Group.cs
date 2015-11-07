using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.DATA.Entities
{
    public class GroupEntity
    {
        public int groupId { get; set; }
        public int creatorFK { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public bool isPrivate { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonFK { get; set; }
    }
}
