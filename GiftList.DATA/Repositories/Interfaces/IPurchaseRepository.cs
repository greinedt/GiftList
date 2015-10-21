using System.Collections.Generic;
using GiftList.DATA.Entities;

namespace GiftList.DATA.Repositories
{
    public interface IPurchaseRepository
    {
        IList<Purchase> GetAllPurchases(string query, int page, int pageSize);
        long GetNumberOfPurchases(string query);
        bool PurchaseExists(int item, int purchaser);
        Purchase GetPurchaseById(int id);
        Purchase GetPurchase(int item, int purchaser);
        long Insert(Purchase purchase);
        void Update(int id, Purchase purchase);
        void Delete(int id);
    }
}
