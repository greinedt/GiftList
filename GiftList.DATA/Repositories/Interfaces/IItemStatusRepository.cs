using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IItemStatusRepository
    {
        IList<ItemStatus> GetAllItemStatuss(string query, int page, int pageSize);
        long GetNumberOfItemStatuss(string query);
        bool ItemStatusExists(string status);
        ItemStatus GetItemStatusById(int id);
        ItemStatus GetItemStatus(string status);
        long Insert(ItemStatus itemStatus);
        void Update(int id, ItemStatus itemStatus);
        void Delete(int id);
    }
}
