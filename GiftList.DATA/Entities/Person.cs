using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.DATA.Entities
{
    public class Person
    {
        public int personId { get; set; }
        public string userName { get; set; }
        public string emailAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string passwordHash { get; set; }
        public DateTime updateTimestamp { get; set; }
    }
}
