using System;
using System.Collections.Generic;
using System.Linq;
using TheGiftList.BAL.Entities;
using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class ItemBL : IItemBL
    {
        private IItemRepository repo;

        public ItemBL()
        {
            repo = new ItemRepository();
        }

        public Item GetById(int id)
        {
            return Translate.Item(repo.GetItemById(id));
        }

        public List<Item> GetAll()
        {
            return Translate.Item(repo.GetAllItems().ToList());
        }
    }
}
