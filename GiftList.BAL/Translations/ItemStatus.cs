using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static ItemStatusBL ItemStatus(ItemStatusEntity data)
        {
            ItemStatusBL bl = new ItemStatusBL();

            bl.ItemStatusId = data.itemStatusId;
            bl.Status = data.status;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<ItemStatusBL> ItemStatus(List<ItemStatusEntity> dataList)
        {
            List<ItemStatusBL> blList = new List<ItemStatusBL>();
            foreach (ItemStatusEntity data in dataList)
            {
                blList.Add(ItemStatus(data));
            }
            return blList;
        }

        public static ItemStatusEntity ItemStatus(ItemStatusBL bl)
        {
            ItemStatusEntity data = new ItemStatusEntity();

            data.itemStatusId = bl.ItemStatusId;
            data.status = bl.Status;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<ItemStatusEntity> GiftList(List<ItemStatusBL> blList)
        {
            List<ItemStatusEntity> dataList = new List<ItemStatusEntity>();
            foreach (ItemStatusBL bl in blList)
            {
                dataList.Add(ItemStatus(bl));
            }
            return dataList;
        }
    }
}
