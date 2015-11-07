using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGroupMemberRepository
    {
        IList<GroupMemberEntity> GetAllGroupMembers();
        IList<GroupMemberEntity> GetAllGroupMembers(int group);
        long GetNumberOfGroupMembers(int group);
        bool GroupMemberExists(int group, int member);
        GroupMemberEntity GetGroupMemberById(int id);
        GroupMemberEntity GetGroupMember(int group, int member);
        long Insert(GroupMemberEntity groupMember);
        void Insert(List<GroupMemberEntity> batch);
        void Update(int id, GroupMemberEntity groupMember);
        void Update(List<GroupMemberEntity> batch);
        void Delete(int id);
        void Delete(List<int> batch);
    }
}
