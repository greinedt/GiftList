using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class ListRepository : IGiftListRepository
    {

        public IList<GiftList> GetAllGiftLists()
        {
            throw new NotImplementedException();
        }

        public IList<GiftList> GetAllGiftLists(int person)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOGiftfLists(int person)
        {
            throw new NotImplementedException();
        }

        public bool GiftListExists(int person, string giftListName)
        {
            throw new NotImplementedException();
        }

        public GiftList GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public GiftList GetList(int person, string giftListName)
        {
            throw new NotImplementedException();
        }

        public long Insert(GiftList giftList)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, GiftList giftList)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
