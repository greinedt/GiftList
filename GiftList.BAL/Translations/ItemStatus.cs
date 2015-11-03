using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static ItemStatusBL ItemStatus(ItemStatus data)
        {
            ItemStatusBL bl = new ItemStatusBL();

            bl.ItemStatusId = data.itemStatusId;
            bl.Status = data.status;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<ItemStatusBL> ItemStatus(List<ItemStatus> dataList)
        {
            List<ItemStatusBL> blList = new List<ItemStatusBL>();
            foreach (ItemStatus data in dataList)
            {
                blList.Add(Translate.ItemStatus(data));
            }
            return blList;
        }

        public static ItemStatus ItemStatus(ItemStatusBL bl)
        {
            ItemStatus data = new ItemStatus();

            data.itemStatusId = bl.ItemStatusId;
            data.status = bl.Status;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<ItemStatus> GiftList(List<ItemStatusBL> blList)
        {
            List<ItemStatus> dataList = new List<ItemStatus>();
            foreach (ItemStatusBL bl in blList)
            {
                dataList.Add(Translate.ItemStatus(bl));
            }
            return dataList;
        }
    }
}
