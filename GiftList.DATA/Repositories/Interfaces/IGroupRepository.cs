using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGroupRepository
    {
        IList<Group> GetAllGroups();
        IList<Group> GetAllGroups(int creator);
        long GetNumberOfGroups(int creator);
        bool GroupExists(int creator, string groupName);
        Group GetGroupById(int id);
        Group GetGroup(int creator, string groupName);
        long Insert(Group Group);
        void Update(int id, Group group);
        void Delete(int id);
        void Insert(List<Group> batch);
        void Update(List<Group> batch);
        void Delete(List<int> batch);
    }
}
