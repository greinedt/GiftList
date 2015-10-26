using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGroupMemberRepository 
    {
        IList<GroupMember> GetAllGroupMembers(int group);
        long GetNumberOfGroupMembers(int group);
        bool GroupMemberExists(int group, int member);
        GroupMember GetGroupMemberById(int id);
        GroupMember GetGroupMember(int group, int member);
        long Insert(GroupMember groupMember);
        void Update(int id, GroupMember groupMember);
        void Delete(int id);
    }
}
