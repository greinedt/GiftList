using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static ItemBL Item(Item data)
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

        public static List<ItemBL> Item(List<Item> dataList)
        {
            List<ItemBL> blList = new List<ItemBL>();
            foreach (Item data in dataList)
            {
                blList.Add(Translate.Item(data));
            }
            return blList;
        }

        public static Item Item(ItemBL bl)
        {
            Item data = new Item();

            data.itemId = bl.ItemId;
            data.itemStatusFK = bl.ItemStatusFK;
            data.giftListFK = bl.GiftListFK;
            data.itemName = bl.ItemName;
            data.description = bl.Description;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<Item> Item(List<ItemBL> blList)
        {
            List<Item> dataList = new List<Item>();
            foreach (ItemBL bl in blList)
            {
                dataList.Add(Translate.Item(bl));
            }
            return dataList;
        }

    }
}
