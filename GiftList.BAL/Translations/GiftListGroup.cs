using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;



namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GiftListGroupBL GiftListGroup(GiftListGroupEntity data)
        {
            GiftListGroupBL bl = new GiftListGroupBL();

            bl.GiftListGroupId = data.giftListGroupId;
            bl.GiftListFK = data.giftListFK;
            bl.GroupFK = data.groupFK;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<GiftListGroupBL> GiftListGroup(List<GiftListGroupEntity> dataList)
        {
            List<GiftListGroupBL> blList = new List<GiftListGroupBL>();
            foreach (GiftListGroupEntity data in dataList)
            {
                blList.Add(GiftListGroup(data));
            }
            return blList;
        }

        public static GiftListGroupEntity GiftListGroup(GiftListGroupBL bl)
        {
            GiftListGroupEntity data = new GiftListGroupEntity();

            data.giftListGroupId = bl.GiftListGroupId;
            data.giftListFK = bl.GiftListFK;
            data.groupFK = bl.GroupFK;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<GiftListGroupBL> GiftList(List<GiftListGroupEntity> blList)
        {
            List<GiftListGroupBL> dataList = new List<GiftListGroupBL>();
            foreach (GiftListGroupEntity bl in blList)
            {
                dataList.Add(GiftListGroup(bl));
            }
            return dataList;
        }
    }
}
