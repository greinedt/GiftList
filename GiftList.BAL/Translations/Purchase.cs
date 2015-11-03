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

            bl.PurchaseId = data.purchaseId;
            bl.ItemFK = data.itemFK;
            bl.PurchaserFK = data.purchaserFK;
            bl.PurchaseDate = data.purchaseDate;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

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
