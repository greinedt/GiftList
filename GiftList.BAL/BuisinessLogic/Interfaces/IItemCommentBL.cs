using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IItemCommentBL
    {
        List<ItemComment> GetAll();
        ItemComment GetById(int id);
    }
}
