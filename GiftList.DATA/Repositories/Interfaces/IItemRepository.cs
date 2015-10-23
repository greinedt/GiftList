﻿using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IItemRepository
    {
        IList<Item> GetAllItems(string query, int page, int pageSize);
        long GetNumberOfItems(string query);
        bool ItemExists(int group, int member);
        Item GetItemById(int id);
        Item GetItem(int giftList, string itemName);
        long Insert(Item item);
        void Update(int id, Item item);
        void Delete(int id);
    }
}
