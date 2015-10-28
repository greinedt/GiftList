using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.Item Item(TheGiftList.DATA.Entities.Item data)
        {
            Entities.Item bal = new Entities.Item();

            bal.itemId = data.itemId;
            bal.itemStatusFK = data.itemStatusFK;
            bal.giftListFK = data.giftListFK;
            bal.itemName = data.itemName;
            bal.description = data.description;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
