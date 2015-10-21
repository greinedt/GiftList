using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftList.DATA.Entities;
using GiftList.DATA.Repositories.Interfaces;

namespace GiftList.DATA.Repositories
{
    public class ItemCommentRepository : IItemCommentRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemComment> GetAllItemComments(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ItemComment GetItemCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public ItemComment GetItemCommentByItem(Item item)
        {
            throw new NotImplementedException();
        }

        public ItemComment GetItemCommentByItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfItemComments(string query)
        {
            throw new NotImplementedException();
        }

        public long Insert(ItemComment itemComment)
        {
            throw new NotImplementedException();
        }

        public bool ItemCommentExists(int group, int member)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ItemComment itemComment)
        {
            throw new NotImplementedException();
        }
    }
}
