using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftList.DATA.Entities;
using GiftList.DATA.Repositories.Interfaces;

namespace GiftList.DATA.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetAllItems(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int list, string itemName)
        {
            throw new NotImplementedException();
        }

        public Item GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfItems(string query)
        {
            throw new NotImplementedException();
        }

        public long Insert(Item item)
        {
            throw new NotImplementedException();
        }

        public bool ItemExists(int group, int member)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
