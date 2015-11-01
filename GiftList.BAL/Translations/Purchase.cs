using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.Purchase Purchase(TheGiftList.DATA.Entities.Purchase data)
        {
            Entities.Purchase ent = new Entities.Purchase();

            ent.purchaseId = data.purchaseId;
            ent.itemFK = data.itemFK;
            ent.purchaserFK = data.purchaserFK;
            ent.purchaseDate = data.purchaseDate;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
