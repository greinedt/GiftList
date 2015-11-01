using System;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;


namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.GiftListGroup GiftListGroup(TheGiftList.DATA.Entities.GiftListGroup data)
        {
            Entities.GiftListGroup ent = new Entities.GiftListGroup();

            ent.giftListGroupId = data.giftListGroupId;
            ent.giftListFK = data.giftListFK;
            ent.groupFK = data.groupFK;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
