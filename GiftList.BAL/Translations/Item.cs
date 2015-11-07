using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    internal static partial class Translate
    {
        internal static Item Item(ItemEntity data)
        {
            Item ent = new Item();

            ent.Id = data.itemId;
            ent.ItemStatusFK = data.itemStatusFK;
            ent.GiftListFK = data.giftListFK;
            ent.ItemName = data.itemName;
            ent.Description = data.description;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        internal static List<Item> Item(List<ItemEntity> dataList)
        {
            List<Item> entList = new List<Item>();
            foreach (ItemEntity data in dataList)
            {
                entList.Add(Item(data));
            }
            return entList;
        }

        internal static ItemEntity Item(Item ent)
        {
            ItemEntity data = new ItemEntity();

            data.itemId = ent.Id;
            data.itemStatusFK = ent.ItemStatusFK;
            data.giftListFK = ent.GiftListFK;
            data.itemName = ent.ItemName;
            data.description = ent.Description;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        internal static List<ItemEntity> Item(List<Item> entList)
        {
            List<ItemEntity> dataList = new List<ItemEntity>();
            foreach (Item ent in entList)
            {
                dataList.Add(Item(ent));
            }
            return dataList;
        }

    }
}
