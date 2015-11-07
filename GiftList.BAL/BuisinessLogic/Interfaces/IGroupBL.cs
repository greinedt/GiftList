using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IGroupBL
    {
        List<Group> GetAll();
        Group GetById(int id);
    }
}
