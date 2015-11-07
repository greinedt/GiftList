using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IPurchaseRepository
    {
        IList<PurchaseEntity> GetAllPurchases();
        IList<PurchaseEntity> GetAllPurchases(int purchaser);
        long GetNumberOfPurchases(int purchaser);
        bool PurchaseExists(int item, int purchaser);
        PurchaseEntity GetPurchaseById(int id);
        PurchaseEntity GetPurchase(int item, int purchaser);
        long Insert(PurchaseEntity purchase);
        void Update(int id, PurchaseEntity purchase);
        void Delete(int id);
        void Insert(List<PurchaseEntity> batch);
        void Update(List<PurchaseEntity> batch);
        void Delete(List<int> batch);
    }
}
