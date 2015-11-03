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
    }
}
