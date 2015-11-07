using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IGiftListBL
    {
        List<GiftList> GetAll();
        GiftList GetById(int id);
    }
}
