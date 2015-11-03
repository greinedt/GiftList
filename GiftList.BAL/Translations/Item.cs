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

            //ent.itemId = data.itemId;
            //ent.itemStatusFK = data.itemStatusFK;
            //ent.giftListFK = data.giftListFK;
            //ent.itemName = data.itemName;
            //ent.description = data.description;
            //ent.updateTimestamp = data.updateTimestamp;
            //ent.updatePersonFK = data.updatePersonFK;

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
