using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGiftListGroupRepository
    {
        IList<GiftListGroupEntity> GetAllGiftListGroups();
        IList<GiftListGroupEntity> GetAllGiftListGroups(IConnection conn);
        IList<GiftListGroupEntity> GetAllGiftListGroups(int group);
        IList<GiftListGroupEntity> GetAllGiftListGroups(int group, IConnection conn);
        long GetNumberOfGiftListGroups(int group);
        long GetNumberOfGiftListGroups(int group, IConnection conn);
        bool GiftListGroupExists(int giftList, int group);
        bool GiftListGroupExists(int giftList, int group, IConnection conn);
        GiftListGroupEntity GetGiftListGroupById(int id);
        GiftListGroupEntity GetGiftListGroupById(int id, IConnection conn);
        GiftListGroupEntity GetGiftListGroup(int giftList, int group);
        GiftListGroupEntity GetGiftListGroup(int giftList, int group, IConnection conn);
        long Insert(GiftListGroupEntity giftListGroup);
        long Insert(GiftListGroupEntity giftListGroup, IConnection conn);
        void Insert(List<GiftListGroupEntity> batch);
        void Insert(List<GiftListGroupEntity> batch, IConnection conn);
        void Update(int id, GiftListGroupEntity giftListGroup);
        void Update(int id, GiftListGroupEntity giftListGroup, IConnection conn);
        void Update(List<GiftListGroupEntity> batch);
        void Update(List<GiftListGroupEntity> batch, IConnection conn);
        void Delete(int id);
        void Delete(int id, IConnection conn);
        void Delete(List<int> batch);
        void Delete(List<int> batch, IConnection conn);
    }
}
