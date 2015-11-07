using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGroupRepository
    {
        IList<GroupEntity> GetAllGroups();
        IList<GroupEntity> GetAllGroups(int creator);
        long GetNumberOfGroups(int creator);
        bool GroupExists(int creator, string groupName);
        GroupEntity GetGroupById(int id);
        GroupEntity GetGroup(int creator, string groupName);
        long Insert(GroupEntity Group);
        void Update(int id, GroupEntity group);
        void Delete(int id);
        void Insert(List<GroupEntity> batch);
        void Update(List<GroupEntity> batch);
        void Delete(List<int> batch);
    }
}
