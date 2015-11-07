using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static ItemBL Item(ItemEntity data)
        {
            ItemBL bl = new ItemBL();

            bl.ItemId = data.itemId;
            bl.ItemStatusFK = data.itemStatusFK;
            bl.GiftListFK = data.giftListFK;
            bl.ItemName = data.itemName;
            bl.Description = data.description;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<ItemBL> Item(List<ItemEntity> dataList)
        {
            List<ItemBL> blList = new List<ItemBL>();
            foreach (ItemEntity data in dataList)
            {
                blList.Add(Item(data));
            }
            return blList;
        }

        public static ItemEntity Item(ItemBL bl)
        {
            ItemEntity data = new ItemEntity();

            data.itemId = bl.ItemId;
            data.itemStatusFK = bl.ItemStatusFK;
            data.giftListFK = bl.GiftListFK;
            data.itemName = bl.ItemName;
            data.description = bl.Description;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<ItemEntity> Item(List<ItemBL> blList)
        {
            List<ItemEntity> dataList = new List<ItemEntity>();
            foreach (ItemBL bl in blList)
            {
                dataList.Add(Item(bl));
            }
            return dataList;
        }

    }
}
