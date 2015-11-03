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

            //ent.itemStatusId = data.itemStatusId;
            //ent.status = data.status;
            //ent.updateTimestamp = data.updateTimestamp;
            //ent.updatePersonFK = data.updatePersonFK;

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
    }
}
