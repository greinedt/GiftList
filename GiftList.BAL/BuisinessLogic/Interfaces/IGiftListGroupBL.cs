using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IGiftListGroupBL
    {
        List<GiftListGroup> GetAll();
        GiftListGroup GetById(int id);
    }
}
