using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftList.DATA.Entities;
using GiftList.DATA.Repositories.Interfaces;

namespace GiftList.DATA.Repositories
{
    public class ItemStatusRepository : IItemStatusRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemStatus> GetAllItemStatuss(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ItemStatus GetItemStatus(string status)
        {
            throw new NotImplementedException();
        }

        public ItemStatus GetItemStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfItemStatuss(string query)
        {
            throw new NotImplementedException();
        }

        public long Insert(ItemStatus itemStatus)
        {
            throw new NotImplementedException();
        }

        public bool ItemStatusExists(string status)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ItemStatus itemStatus)
        {
            throw new NotImplementedException();
        }
    }
}
