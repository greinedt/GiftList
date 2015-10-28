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
            Entities.Group bal = new Entities.Group();

            bal.groupId = data.groupId;
            bal.creatorFK = data.creatorFK;
            bal.description = data.description;
            bal.isPrivate = data.isPrivate;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
