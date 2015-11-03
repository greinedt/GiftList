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

        public static Purchase Purchase(PurchaseBL bl)
        {
            Purchase data = new Purchase();

            data.purchaseId = bl.PurchaseId;
            data.itemFK = bl.ItemFK;
            data.purchaserFK = bl.PurchaserFK;
            data.purchaseDate = bl.PurchaseDate;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<Purchase> Purchase(List<PurchaseBL> blList)
        {
            List<Purchase> dataList = new List<Purchase>();
            foreach (PurchaseBL bl in blList)
            {
                dataList.Add(Translate.Purchase(bl));
            }
            return dataList;
        }
    }
}
