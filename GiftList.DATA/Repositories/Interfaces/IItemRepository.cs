using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IItemRepository
    {
        IList<Item> GetAllItems(int giftList);
        long GetNumberOfItems(int giftList);
        bool ItemExists(int giftList, string itemName);
        Item GetItemById(int id);
        Item GetItem(int giftList, string itemName);
        long Insert(Item item);
        void Update(int id, Item item);
        void Delete(int id);
    }
}
