using System.Collections.Generic;
using GiftList.DATA.Entities;

namespace GiftList.DATA.Repositories
{
    public interface IListRepository
    {
        IList<List> GetAllLists(string query, int page, int pageSize);
        long GetNumberOfLists(string query);
        bool ListExists(int person, string listName);
        List GetListById(int id);
        List GetList(int person, string listName);
        long Insert(List list);
        void Update(int id, List list);
        void Delete(int id);
    }
}
