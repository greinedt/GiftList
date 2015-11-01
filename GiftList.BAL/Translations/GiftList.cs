using System;
using TheGiftList.DATA.Entities;


namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.GiftList GiftList(TheGiftList.DATA.Entities.GiftList data)
        {
            Entities.GiftList ent = new Entities.GiftList();

            ent.giftListId = data.giftListId;
            ent.personFK = data.personFK;
            ent.listName = data.listName;
            ent.isPrivate = data.isPrivate;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
