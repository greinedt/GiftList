using System;
using TheGiftList.DATA.Entities;


namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.GiftList GiftList(TheGiftList.DATA.Entities.GiftList data)
        {
            Entities.GiftList bal = new Entities.GiftList();

            bal.giftListId = data.giftListId;
            bal.personFK = data.personFK;
            bal.listName = data.listName;
            bal.isPrivate = data.isPrivate;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
