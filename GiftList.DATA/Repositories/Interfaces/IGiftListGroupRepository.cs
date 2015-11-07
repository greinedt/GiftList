using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGiftListGroupRepository
    {
        IList<GiftListGroupEntity> GetAllGiftListGroups();
        IList<GiftListGroupEntity> GetAllGiftListGroups(int group);
        long GetNumberOfGiftListGroups(int group);
        bool GiftListGroupExists(int giftList, int group);
        GiftListGroupEntity GetGiftListGroupById(int id);
        GiftListGroupEntity GetGiftListGroup(int giftList, int group);
        long Insert(GiftListGroupEntity giftListGroup);
        void Insert(List<GiftListGroupEntity> batch);
        void Update(int id, GiftListGroupEntity giftListGroup);
        void Update(List<GiftListGroupEntity> batch);
        void Delete(int id);
        void Delete(List<int> batch);
    }
}
