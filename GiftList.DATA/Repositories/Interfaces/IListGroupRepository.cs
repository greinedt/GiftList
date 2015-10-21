using System.Collections.Generic;
using GiftList.DATA.Entities;

namespace GiftList.DATA.Repositories
{
    public interface IListGroupRepository
    {
        IList<ListGroup> GetAllListGroups(string query, int page, int pageSize);
        long GetNumberOfListGroups(string query);
        bool ListGroupExists(int list, int group);
        ListGroup GetListGroupById(int id);
        ListGroup GetListGroup(int list, int group);
        long Insert(ListGroup ListGroup);
        void Update(int id, ListGroup ListGroup);
        void Delete(int id);
    }
}
