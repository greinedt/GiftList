using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories.Interfaces
{
    public class GroupRepository : IGroupRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Group> GetAllGroups(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Group GetGroup(int creator, string groupName)
        {
            throw new NotImplementedException();
        }

        public Group GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfGroups(string query)
        {
            throw new NotImplementedException();
        }

        public bool GroupExists(int creator, string groupName)
        {
            throw new NotImplementedException();
        }

        public long Insert(Group Group)
        {
            throw new NotImplementedException();
        }

        public void Update(Group Group)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
