using System;
using System.Collections.Generic;
using System.Linq;
using TheGiftList.BAL.Entities;
using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class GiftListGroupBL : IGiftListGroupBL
    {
        private IGiftListGroupRepository repo;

        public GiftListGroupBL()
        {
            repo = new GiftListGroupRepository();
        }

        public List<GiftListGroup> GetAll()
        {
            return Translate.GiftListGroup(repo.GetAllGiftListGroups().ToList());
        }

        public GiftListGroup GetById(int id)
        {
            return Translate.GiftListGroup(repo.GetGiftListGroupById(id));
        }
    }
}
