using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGiftListRepository
    {
        IList<Entities.GiftList> GetAllGiftLists();
        IList<Entities.GiftList> GetAllGiftLists(int person);
        long GetNumberOGiftfLists(int person);
        bool GiftListExists(int person, string giftListName);
        GiftList GetListById(int id);
        GiftList GetList(int person, string giftListName);
        long Insert(Entities.GiftList giftList);
        void Insert(List<Entities.GiftList> batch);
        void Update(int id, Entities.GiftList giftList);
        void Update(List<Entities.GiftList> batch);
        void Delete(int id);
        void Delete(List<int> batch);
    }
}
