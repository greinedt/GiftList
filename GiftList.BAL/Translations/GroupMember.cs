using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.GroupMember GroupMember(TheGiftList.DATA.Entities.GroupMember data)
        {
            Entities.GroupMember bal = new Entities.GroupMember();

            bal.groupMemberId = data.groupMemberId;
            bal.groupFK = data.groupFK;
            bal.memberFK = data.memberFK;
            bal.isAdmin = data.isAdmin;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
