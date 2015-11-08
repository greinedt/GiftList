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
        IList<PurchaseEntity> GetAllPurchases(IConnection conn);
        IList<PurchaseEntity> GetAllPurchases(int purchaser, IConnection conn);
        long GetNumberOfPurchases(int purchaser, IConnection conn);
        bool PurchaseExists(int item, int purchaser, IConnection conn);
        PurchaseEntity GetPurchaseById(int id, IConnection conn);
        PurchaseEntity GetPurchase(int item, int purchaser, IConnection conn);
        long Insert(PurchaseEntity purchase, IConnection conn);
        void Update(int id, PurchaseEntity purchase, IConnection conn);
        void Delete(int id, IConnection conn);
        void Insert(List<PurchaseEntity> batch, IConnection conn);
        void Update(List<PurchaseEntity> batch, IConnection conn);
        void Delete(List<int> batch, IConnection conn);
    }
}
