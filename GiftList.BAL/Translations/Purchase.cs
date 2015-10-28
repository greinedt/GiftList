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
            Entities.Purchase bal = new Entities.Purchase();

            bal.purchaseId = data.purchaseId;
            bal.itemFK = data.itemFK;
            bal.purchaserFK = data.purchaserFK;
            bal.purchaseDate = data.purchaseDate;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
