using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IItemRepository
    {
        IList<ItemEntity> GetAllItems();
        IList<ItemEntity> GetAllItems(int giftList);
        long GetNumberOfItems(int giftList);
        bool ItemExists(int giftList, string itemName);
        ItemEntity GetItemById(int id);
        ItemEntity GetItem(int giftList, string itemName);
        long Insert(ItemEntity item);
        void Update(int id, ItemEntity item);
        void Delete(int id);
        void Insert(List<ItemEntity> batch);
        void Update(List<ItemEntity> batch);
        void Delete(List<int> batch);
    }
}
