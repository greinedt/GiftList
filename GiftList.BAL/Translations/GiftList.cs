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
    }
}
