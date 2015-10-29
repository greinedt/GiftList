using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGroupMemberRepository
    {
        IList<GroupMember> GetAllGroupMembers();
        IList<GroupMember> GetAllGroupMembers(int group);
        long GetNumberOfGroupMembers(int group);
        bool GroupMemberExists(int group, int member);
        GroupMember GetGroupMemberById(int id);
        GroupMember GetGroupMember(int group, int member);
        long Insert(GroupMember groupMember);
        void Insert(List<GroupMember> batch);
        void Update(int id, GroupMember groupMember);
        void Update(List<GroupMember> batch);
        void Delete(int id);
        void Delete(List<int> batch);
    }
}
