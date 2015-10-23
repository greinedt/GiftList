using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.DATA.Repositories.Interfaces;

namespace TheGiftList.DATA.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<GroupMember> GetAllGroupMembers(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public GroupMember GetGroupMember(int group, int member)
        {
            throw new NotImplementedException();
        }

        public GroupMember GetGroupMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfGroupMembers(string query)
        {
            throw new NotImplementedException();
        }

        public bool GroupMemberExists(int group, int member)
        {
            throw new NotImplementedException();
        }

        public long Insert(GroupMember groupMember)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, GroupMember groupMember)
        {
            throw new NotImplementedException();
        }
    }
}
