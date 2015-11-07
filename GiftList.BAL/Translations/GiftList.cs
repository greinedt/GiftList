using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GiftListBL GiftList(GiftListEntity data)
        {
            GiftListBL bl = new GiftListBL();

            bl.GiftListId = data.giftListId;
            bl.PersonFK = data.personFK;
            bl.ListName = data.listName;
            bl.IsPrivate = data.isPrivate;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<GiftListBL> GiftList(List<GiftListEntity> dataList)
        {
            List<GiftListBL> blList = new List<GiftListBL>();
            foreach (GiftListEntity data in dataList)
            {
                blList.Add(GiftList(data));
            }
            return blList;
        }

        public static GiftListEntity GiftList(GiftListBL bl)
        {
            GiftListEntity data = new GiftListEntity();

            data.giftListId = bl.GiftListId;
            data.personFK = bl.PersonFK;
            data.listName = bl.ListName;
            data.isPrivate = bl.IsPrivate;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<GiftListEntity> GiftList(List<GiftListBL> blList)
        {
            List<GiftListEntity> dataList = new List<GiftListEntity>();
            foreach (GiftListBL bl in blList)
            {
                dataList.Add(GiftList(bl));
            }
            return dataList;
        }
    }
}
