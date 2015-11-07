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
        IList<GiftListEntity> GetAllGiftLists(IConnection conn);
        IList<GiftListEntity> GetAllGiftLists(int person, IConnection conn);
        long GetNumberOGiftfLists(int person, IConnection conn);
        bool GiftListExists(int person, string giftListName, IConnection conn);
        GiftListEntity GetListById(int id, IConnection conn);
        GiftListEntity GetList(int person, string giftListName, IConnection conn);
        long Insert(GiftListEntity giftList, IConnection conn);
        void Insert(List<GiftListEntity> batch, IConnection conn);
        void Update(int id, GiftListEntity giftList, IConnection conn);
        void Update(List<GiftListEntity> batch, IConnection conn);
        void Delete(int id, IConnection conn);
        void Delete(List<int> batch, IConnection conn);
    }
}
