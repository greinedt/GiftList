using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IItemBL
    {
        List<Item> GetAll();
        Item GetById(int id);
    }
}
