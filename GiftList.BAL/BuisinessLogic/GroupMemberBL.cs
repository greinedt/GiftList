using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class GroupMemberBL : IGroupMemberBL
    {
        private IGroupMemberRepository repo;

        public GroupMemberBL()
        {
            repo = new GroupMemberRepository();
        }

        public GroupMember GetById(int id)
        {
            return Translate.GroupMember(repo.GetGroupMemberById(id));
        }
        
        public List<GroupMember> GetAll()
        {
            return Translate.GroupMember(repo.GetAllGroupMembers().ToList());
        }
    }
}
