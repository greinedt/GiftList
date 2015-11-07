using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static PurchaseBL Purchase(PurchaseEntity data)
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

        public static List<PurchaseBL> Purchase(List<PurchaseEntity> dataList)
        {
            List<PurchaseBL> blList = new List<PurchaseBL>();
            foreach (PurchaseEntity data in dataList)
            {
                blList.Add(Purchase(data));
            }
            return blList;
        }

        public static PurchaseEntity Purchase(PurchaseBL bl)
        {
            PurchaseEntity data = new PurchaseEntity();

            data.purchaseId = bl.PurchaseId;
            data.itemFK = bl.ItemFK;
            data.purchaserFK = bl.PurchaserFK;
            data.purchaseDate = bl.PurchaseDate;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<PurchaseEntity> Purchase(List<PurchaseBL> blList)
        {
            List<PurchaseEntity> dataList = new List<PurchaseEntity>();
            foreach (PurchaseBL bl in blList)
            {
                dataList.Add(Purchase(bl));
            }
            return dataList;
        }
    }
}
