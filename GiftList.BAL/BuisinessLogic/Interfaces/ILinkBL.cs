using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface ILinkBL
    {
        List<Link> GetAll();
        Link GetById(int id);
    }
}
