using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;



namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GiftListGroup GiftListGroup(GiftListGroupEntity data)
        {
            GiftListGroup ent = new GiftListGroup();

            ent.Id = data.giftListGroupId;
            ent.GiftListFK = data.giftListFK;
            ent.GroupFK = data.groupFK;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        public static List<GiftListGroup> GiftListGroup(List<GiftListGroupEntity> dataList)
        {
            List<GiftListGroup> entList = new List<GiftListGroup>();
            foreach (GiftListGroupEntity data in dataList)
            {
                entList.Add(GiftListGroup(data));
            }
            return entList;
        }

        public static GiftListGroupEntity GiftListGroup(GiftListGroup ent)
        {
            GiftListGroupEntity data = new GiftListGroupEntity();

            data.giftListGroupId = ent.Id;
            data.giftListFK = ent.GiftListFK;
            data.groupFK = ent.GroupFK;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        public static List<GiftListGroupEntity> GiftListGroup(List<GiftListGroup> entList)
        {
            List<GiftListGroupEntity> dataList = new List<GiftListGroupEntity>();
            foreach (GiftListGroup ent in entList)
            {
                dataList.Add(GiftListGroup(ent));
            }
            return dataList;
        }
    }
}
