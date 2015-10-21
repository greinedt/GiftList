using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftList.DATA.Entities;
using GiftList.DATA.Repositories.Interfaces;

namespace GiftList.DATA.Repositories
{
    public class ListGroupRepository : IListGroupRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ListGroup> GetAllListGroups(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ListGroup GetListGroup(int list, int group)
        {
            throw new NotImplementedException();
        }

        public ListGroup GetListGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfListGroups(string query)
        {
            throw new NotImplementedException();
        }

        public long Insert(ListGroup ListGroup)
        {
            throw new NotImplementedException();
        }

        public bool ListGroupExists(int list, int group)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ListGroup ListGroup)
        {
            throw new NotImplementedException();
        }
    }
}
