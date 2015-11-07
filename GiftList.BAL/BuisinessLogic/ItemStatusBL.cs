using System;
using System.Collections.Generic;
using System.Linq;
using TheGiftList.BAL.Entities;
using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class ItemStatusBL : IItemStatusBL
    {
        private IItemStatusRepository repo;

        public ItemStatusBL()
        {
            repo = new ItemStatusRepository();
        }

        public ItemStatus GetById(int id)
        {
            return Translate.ItemStatus(repo.GetItemStatusById(id));
        }

        public List<ItemStatus> GetAll()
        {
            return Translate.ItemStatus(repo.GetAllItemStatuss().ToList());
        }
    }
}
