using System.Collections.Generic;
using GiftList.DATA.Entities;

namespace GiftList.DATA.Repositories
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
