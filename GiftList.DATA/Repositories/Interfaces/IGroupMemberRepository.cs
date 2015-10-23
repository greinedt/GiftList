using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGroupMemberRepository 
    {
        IList<GroupMember> GetAllGroupMembers(string query, int page, int pageSize);
        long GetNumberOfGroupMembers(string query);
        bool GroupMemberExists(int group, int member);
        GroupMember GetGroupMemberById(int id);
        GroupMember GetGroupMember(int group, int member);
        long Insert(GroupMember groupMember);
        void Update(int id, GroupMember groupMember);
        void Delete(int id);
    }
}
