using System;
using System.Collections.Generic;
using System.Linq;
using TheGiftList.BAL.Entities;
using TheGiftList.DATA.Repositories;


namespace TheGiftList.BAL.BuisinessLogic
{
    public class GiftListBL : IGiftListBL
    {
        private IGiftListRepository repo;

        public GiftListBL()
        {
            repo = new GiftListRepository();
        }

        public GiftList GetById(int id)
        {
            return Translate.GiftList(repo.GetListById(id));
        }

        public List<GiftList> GetAll()
        {
            repo.GetAllGiftLists();
            return Translate.GiftList(repo.GetAllGiftLists().ToList());
        }
    }
}
