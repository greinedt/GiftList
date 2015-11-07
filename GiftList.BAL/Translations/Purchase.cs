using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    internal static partial class Translate
    {
        internal static Purchase Purchase(PurchaseEntity data)
        {
            Purchase ent = new Purchase();

            ent.Id = data.purchaseId;
            ent.ItemFK = data.itemFK;
            ent.PurchaserFK = data.purchaserFK;
            ent.PurchaseDate = data.purchaseDate;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        internal static List<Purchase> Purchase(List<PurchaseEntity> dataList)
        {
            List<Purchase> entList = new List<Purchase>();
            foreach (PurchaseEntity data in dataList)
            {
                entList.Add(Purchase(data));
            }
            return entList;
        }

        internal static PurchaseEntity Purchase(Purchase ent)
        {
            PurchaseEntity data = new PurchaseEntity();

            data.purchaseId = ent.Id;
            data.itemFK = ent.ItemFK;
            data.purchaserFK = ent.PurchaserFK;
            data.purchaseDate = ent.PurchaseDate;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        internal static List<PurchaseEntity> Purchase(List<Purchase> entList)
        {
            List<PurchaseEntity> dataList = new List<PurchaseEntity>();
            foreach (Purchase ent in entList)
            {
                dataList.Add(Purchase(ent));
            }
            return dataList;
        }
    }
}
