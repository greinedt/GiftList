using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.Group Group(TheGiftList.DATA.Entities.Group data)
        {
            Entities.Group ent = new Entities.Group();

            ent.groupId = data.groupId;
            ent.creatorFK = data.creatorFK;
            ent.description = data.description;
            ent.isPrivate = data.isPrivate;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
