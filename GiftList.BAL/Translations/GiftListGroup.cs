using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;



namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GiftListGroupBL GiftListGroup(GiftListGroup data)
        {
            GiftListGroupBL bl = new GiftListGroupBL();

            bl.GiftListGroupId = data.giftListGroupId;
            bl.GiftListFK = data.giftListFK;
            bl.GroupFK = data.groupFK;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<GiftListGroupBL> GiftListGroup(List<GiftListGroup> dataList)
        {
            List<GiftListGroupBL> blList = new List<GiftListGroupBL>();
            foreach (GiftListGroup data in dataList)
            {
                blList.Add(Translate.GiftListGroup(data));
            }
            return blList;
        }

        public static GiftListGroup GiftListGroup(GiftListGroupBL bl)
        {
            GiftListGroup data = new GiftListGroup();

            data.giftListGroupId = bl.GiftListGroupId;
            data.giftListFK = bl.GiftListFK;
            data.groupFK = bl.GroupFK;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<GiftListGroupBL> GiftList(List<GiftListGroup> blList)
        {
            List<GiftListGroupBL> dataList = new List<GiftListGroupBL>();
            foreach (GiftListGroup bl in blList)
            {
                dataList.Add(Translate.GiftListGroup(bl));
            }
            return dataList;
        }
    }
}
