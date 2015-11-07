using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IPurchaseBL
    {
        List<Purchase> GetAll();
        Purchase GetById(int id);
    }
}
