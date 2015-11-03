using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static PurchaseBL Purchase(Purchase data)
        {
            PurchaseBL bl = new PurchaseBL();

            //ent.purchaseId = data.purchaseId;
            //ent.itemFK = data.itemFK;
            //ent.purchaserFK = data.purchaserFK;
            //ent.purchaseDate = data.purchaseDate;
            //ent.updateTimestamp = data.updateTimestamp;
            //ent.updatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<PurchaseBL> Purchase(List<Purchase> dataList)
        {
            List<PurchaseBL> blList = new List<PurchaseBL>();
            foreach (Purchase data in dataList)
            {
                blList.Add(Translate.Purchase(data));
            }
            return blList;
        }
    }
}
