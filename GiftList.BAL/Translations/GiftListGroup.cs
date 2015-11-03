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

        public static List<GiftListGroupBL> Group(List<GiftListGroup> dataList)
        {
            List<GiftListGroupBL> blList = new List<GiftListGroupBL>();
            foreach (GiftListGroup data in dataList)
            {
                blList.Add(Translate.GiftListGroup(data));
            }
            return blList;
        }
    }
}
