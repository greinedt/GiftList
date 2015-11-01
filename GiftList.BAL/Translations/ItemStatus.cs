using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.ItemStatus ItemStatus(TheGiftList.DATA.Entities.ItemStatus data)
        {
            Entities.ItemStatus ent = new Entities.ItemStatus();

            ent.itemStatusId = data.itemStatusId;
            ent.status = data.status;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
