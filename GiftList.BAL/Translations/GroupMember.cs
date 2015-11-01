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
            Entities.GroupMember ent = new Entities.GroupMember();

            ent.groupMemberId = data.groupMemberId;
            ent.groupFK = data.groupFK;
            ent.memberFK = data.memberFK;
            ent.isAdmin = data.isAdmin;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
