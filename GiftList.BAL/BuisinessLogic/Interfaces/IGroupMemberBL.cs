using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IGroupMemberBL
    {
        List<GroupMember> GetAll();
        GroupMember GetById(int id);
    }
}
