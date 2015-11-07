using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class GroupBL : IGroupBL
    {
        private IGroupRepository repo;

        public GroupBL()
        {
            repo = new GroupRepository();
        }
        public Group GetById(int id)
        {
            return Translate.Group(repo.GetGroupById(id));
        }

        public List<Group> GetAll()
        {
            return Translate.Group(repo.GetAllGroups().ToList());
        }
    }
}
