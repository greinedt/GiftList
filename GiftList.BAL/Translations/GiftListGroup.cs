using System;
using TheGiftList.DATA.Entities;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.GiftListGroup GiftListGroup(TheGiftList.DATA.Entities.GiftListGroup data)
        {
            Entities.GiftListGroup bal = new Entities.GiftListGroup();

            bal.giftListGroupId = data.giftListGroupId;
            bal.giftListFK = data.giftListFK;
            bal.groupFK = data.groupFK;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
