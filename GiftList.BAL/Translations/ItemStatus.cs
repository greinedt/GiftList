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
            Entities.ItemStatus bal = new Entities.ItemStatus();

            bal.itemStatusId = data.itemStatusId;
            bal.status = data.status;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
