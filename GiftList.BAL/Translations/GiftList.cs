using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    internal static partial class Translate
    {
        internal static GiftList GiftList(GiftListEntity data)
        {
            GiftList ent = new GiftList();

            ent.Id = data.giftListId;
            ent.PersonFK = data.personFK;
            ent.ListName = data.listName;
            ent.IsPrivate = data.isPrivate;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        internal static List<GiftList> GiftList(List<GiftListEntity> dataList)
        {
            List<GiftList> entList = new List<GiftList>();
            foreach (GiftListEntity data in dataList)
            {
                entList.Add(GiftList(data));
            }
            return entList;
        }

        internal static GiftListEntity GiftList(GiftList ent)
        {
            GiftListEntity data = new GiftListEntity();

            data.giftListId = ent.Id;
            data.personFK = ent.PersonFK;
            data.listName = ent.ListName;
            data.isPrivate = ent.IsPrivate;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        internal static List<GiftListEntity> GiftList(List<GiftList> entList)
        {
            List<GiftListEntity> dataList = new List<GiftListEntity>();
            foreach (GiftList ent in entList)
            {
                dataList.Add(GiftList(ent));
            }
            return dataList;
        }
    }
}
