using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.DATA.Entities
{
    public class Link
    {
        public int linkId { get; set; }
        public int itemFK { get; set; }
        public string linkName { get; set; }
        public string url { get; set; }
        public bool isImage { get; set; }
        public DateTime updateTimestamp { get; set; }
        public int updatePersonFK { get; set; }
    }
}
