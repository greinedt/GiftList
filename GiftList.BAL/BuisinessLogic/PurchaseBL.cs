using System;
using System.Collections.Generic;
using System.Linq;
using TheGiftList.BAL.Entities;
using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class PurchaseBL : IPurchaseBL
    {
        private IPurchaseRepository repo;

        public PurchaseBL()
        {
            repo = new PurchaseRepository();
        }

        public Purchase GetById(int id)
        {
            return Translate.Purchase(repo.GetPurchaseById(id));
        }

        public List<Purchase> GetAll()
        {
            return Translate.Purchase(repo.GetAllPurchases().ToList());
        }
    }
}
