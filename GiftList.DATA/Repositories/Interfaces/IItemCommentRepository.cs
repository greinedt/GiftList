using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IItemCommentRepository
    {
        IList<ItemComment> GetAllItemComments(int item);
        long GetNumberOfItemComments(int item);
        ItemComment GetItemCommentById(int id);
        ItemComment GetItemCommentByItem(int itemId);
        long Insert(ItemComment itemComment);
        void Update(int id, ItemComment itemComment);
        void Delete(int id);
    }
}
