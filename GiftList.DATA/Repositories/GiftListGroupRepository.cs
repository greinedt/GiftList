using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheGiftList.DATA.Entities;
using TheGiftList.DATA.Repositories;

namespace TheGiftList.DATA.Repositories
{
    public class ListGroupRepository : IGiftListGroupRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<GiftListGroup> GetAllGiftListGroups(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public GiftListGroup GetGiftListGroup(int giftList, int group)
        {
            throw new NotImplementedException();
        }

        public GiftListGroup GetGiftListGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfGiftListGroups(string query)
        {
            throw new NotImplementedException();
        }

        public bool GiftListGroupExists(int giftList, int group)
        {
            throw new NotImplementedException();
        }

        public long Insert(GiftListGroup giftListGroup)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, GiftListGroup giftListGroup)
        {
            throw new NotImplementedException();
        }
    }
}
