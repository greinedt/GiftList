using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IItemCommentRepository
    {
        IList<ItemCommentEntity> GetAllItemComments();
        IList<ItemCommentEntity> GetAllItemComments(int item);
        long GetNumberOfItemComments(int item);
        ItemCommentEntity GetItemCommentById(int id);
        ItemCommentEntity GetItemCommentByItem(int itemId);
        long Insert(ItemCommentEntity itemComment);
        void Update(int id, ItemCommentEntity itemComment);
        void Delete(int id);
        void Insert(List<ItemCommentEntity> batch);
        void Update(List<ItemCommentEntity> batch);
        void Delete(List<int> id);
    }
}
