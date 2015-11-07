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
        IList<ItemEntity> GetAllItems(IConnection conn);
        IList<ItemEntity> GetAllItems(int giftList, IConnection conn);
        long GetNumberOfItems(int giftList, IConnection conn);
        bool ItemExists(int giftList, string itemName, IConnection conn);
        ItemEntity GetItemById(int id, IConnection conn);
        ItemEntity GetItem(int giftList, string itemName, IConnection conn);
        long Insert(ItemEntity ite, IConnection connm);
        void Update(int id, ItemEntity item, IConnection conn);
        void Delete(int id, IConnection conn);
        void Insert(List<ItemEntity> batch, IConnection conn);
        void Update(List<ItemEntity> batch, IConnection conn);
        void Delete(List<int> batch, IConnection conn);
    }
}
