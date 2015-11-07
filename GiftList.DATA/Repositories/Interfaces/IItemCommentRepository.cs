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
        IList<ItemCommentEntity> GetAllItemComments(IConnection conn);
        IList<ItemCommentEntity> GetAllItemComments(int item, IConnection conn);
        long GetNumberOfItemComments(int item, IConnection conn);
        ItemCommentEntity GetItemCommentById(int id, IConnection conn);
        ItemCommentEntity GetItemCommentByItem(int itemId, IConnection conn);
        long Insert(ItemCommentEntity itemComment, IConnection conn);
        void Update(int id, ItemCommentEntity itemComment, IConnection conn);
        void Delete(int id, IConnection conn);
        void Insert(List<ItemCommentEntity> batch, IConnection conn);
        void Update(List<ItemCommentEntity> batch, IConnection conn);
        void Delete(List<int> id, IConnection conn);
    }
}
