using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGiftListRepository
    {
        IList<GiftListEntity> GetAllGiftLists();
        IList<GiftListEntity> GetAllGiftLists(int person);
        long GetNumberOGiftfLists(int person);
        bool GiftListExists(int person, string giftListName);
        GiftListEntity GetListById(int id);
        GiftListEntity GetList(int person, string giftListName);
        long Insert(GiftListEntity giftList);
        void Insert(List<GiftListEntity> batch);
        void Update(int id, GiftListEntity giftList);
        void Update(List<GiftListEntity> batch);
        void Delete(int id);
        void Delete(List<int> batch);
    }
}
