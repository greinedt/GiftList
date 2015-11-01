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
            Entities.Item ent = new Entities.Item();

            ent.itemId = data.itemId;
            ent.itemStatusFK = data.itemStatusFK;
            ent.giftListFK = data.giftListFK;
            ent.itemName = data.itemName;
            ent.description = data.description;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
