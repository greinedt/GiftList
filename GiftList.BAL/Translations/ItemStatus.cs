using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static ItemStatus ItemStatus(ItemStatusEntity data)
        {
            ItemStatus ent = new ItemStatus();

            ent.Id = data.itemStatusId;
            ent.Status = data.status;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        public static List<ItemStatus> ItemStatus(List<ItemStatusEntity> dataList)
        {
            List<ItemStatus> entList = new List<ItemStatus>();
            foreach (ItemStatusEntity data in dataList)
            {
                entList.Add(ItemStatus(data));
            }
            return entList;
        }

        public static ItemStatusEntity ItemStatus(ItemStatus ent)
        {
            ItemStatusEntity data = new ItemStatusEntity();

            data.itemStatusId = ent.Id;
            data.status = ent.Status;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        public static List<ItemStatusEntity> ItemStatus(List<ItemStatus> entList)
        {
            List<ItemStatusEntity> dataList = new List<ItemStatusEntity>();
            foreach (ItemStatus ent in entList)
            {
                dataList.Add(ItemStatus(ent));
            }
            return dataList;
        }
    }
}
