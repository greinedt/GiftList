using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IPurchaseRepository
    {
        IList<Purchase> GetAllPurchases();
        IList<Purchase> GetAllPurchases(int purchaser);
        long GetNumberOfPurchases(int purchaser);
        bool PurchaseExists(int item, int purchaser);
        Purchase GetPurchaseById(int id);
        Purchase GetPurchase(int item, int purchaser);
        long Insert(Purchase purchase);
        void Update(int id, Purchase purchase);
        void Delete(int id);
        void Insert(List<Purchase> batch);
        void Update(List<Purchase> batch);
        void Delete(List<int> batch);
    }
}
