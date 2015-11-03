using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GiftListBL GiftList(GiftList data)
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

        public static List<GiftListBL> GiftList(List<GiftList> dataList)
        {
            List<GiftListBL> blList = new List<GiftListBL>();
            foreach (GiftList data in dataList)
            {
                blList.Add(Translate.GiftList(data));
            }
            return blList;
        }

        public static GiftList GiftList(GiftListBL bl)
        {
            GiftList data = new GiftList();

            data.giftListId = bl.GiftListId;
            data.personFK = bl.PersonFK;
            data.listName = bl.ListName;
            data.isPrivate = bl.IsPrivate;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<GiftList> GiftList(List<GiftListBL> blList)
        {
            List<GiftList> dataList = new List<GiftList>();
            foreach (GiftListBL bl in blList)
            {
                dataList.Add(Translate.GiftList(bl));
            }
            return dataList;
        }
    }
}
