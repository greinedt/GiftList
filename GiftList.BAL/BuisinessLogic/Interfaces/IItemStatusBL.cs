using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IItemStatusBL
    {
        List<ItemStatus> GetAll();
        ItemStatus GetById(int id);
    }
}
