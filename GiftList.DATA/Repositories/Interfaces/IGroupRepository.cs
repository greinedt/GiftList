using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGroupRepository
    {
        IList<Group> GetAllGroups(string query, int page, int pageSize);
        long GetNumberOfGroups(string query);
        bool GroupExists(int creator, string groupName);
        Group GetGroupById(int id);
        Group GetGroup(int creator, string groupName);
        long Insert(Group Group);
        void Update(int id, Group group);
        void Delete(int id);
    }
}
