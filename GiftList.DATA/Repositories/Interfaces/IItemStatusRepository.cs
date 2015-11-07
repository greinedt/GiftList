using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IItemStatusRepository
    {
        IList<ItemStatusEntity> GetAllItemStatuss();
        long GetNumberOfItemStatus();
        bool ItemStatusExists(string status);
        ItemStatusEntity GetItemStatusById(int id);
        ItemStatusEntity GetItemStatusByStatusName(string status);
        long Insert(ItemStatusEntity itemStatus);
        void Update(int id, ItemStatusEntity itemStatus);
        void Delete(int id);
        void Insert(List<ItemStatusEntity> batch);
        void Update(List<ItemStatusEntity> batch);
        void Delete(List<int> batch);
    }
}
