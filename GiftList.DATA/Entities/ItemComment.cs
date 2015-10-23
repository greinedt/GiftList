using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.DATA.Entities
{
    public class ItemComment
    {
        public int itemCommentId { get; set; }
        public int itemFK { get; set; }
        public int commentorFK { get; set; }
        public string commentText { get; set; }
        public bool isHiddenFromOwner { get; set; }
        public DateTime updateTimeStamp { get; set; }
        public int updatePersonFK { get; set; }
    }
}
