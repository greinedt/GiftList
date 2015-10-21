using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftList.DATA.Entities;
using GiftList.DATA.Repositories.Interfaces;

namespace GiftList.DATA.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Purchase> GetAllPurchases(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfPurchases(string query)
        {
            throw new NotImplementedException();
        }

        public Purchase GetPurchase(int item, int purchaser)
        {
            throw new NotImplementedException();
        }

        public Purchase GetPurchaseById(int id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public bool PurchaseExists(int item, int purchaser)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
