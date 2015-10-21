using System.Collections.Generic;
using GiftList.DATA.Entities;

namespace GiftList.DATA.Repositories
{
    public interface IItemCommentRepository
    {
        IList<ItemComment> GetAllItemComments(string query, int page, int pageSize);
        long GetNumberOfItemComments(string query);
        bool ItemCommentExists(int group, int member);
        ItemComment GetItemCommentById(int id);
        ItemComment GetItemCommentByItem(int itemId);
        ItemComment GetItemCommentByItem(Item item);
        long Insert(ItemComment itemComment);
        void Update(int id, ItemComment itemComment);
        void Delete(int id);
    }
}
