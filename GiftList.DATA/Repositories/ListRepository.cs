using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftList.DATA.Entities;
using GiftList.DATA.Repositories.Interfaces;

namespace GiftList.DATA.Repositories
{
    public class ListRepository : IListRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<List> GetAllLists(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List GetList(int person, string listName)
        {
            throw new NotImplementedException();
        }

        public List GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfLists(string query)
        {
            throw new NotImplementedException();
        }

        public long Insert(List list)
        {
            throw new NotImplementedException();
        }

        public bool ListExists(int person, string listName)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, List list)
        {
            throw new NotImplementedException();
        }
    }
}
