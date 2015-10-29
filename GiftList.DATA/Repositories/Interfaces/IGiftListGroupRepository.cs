using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGiftListGroupRepository
    {
        IList<GiftListGroup> GetAllGiftListGroups();
        IList<GiftListGroup> GetAllGiftListGroups(int group);
        long GetNumberOfGiftListGroups(int group);
        bool GiftListGroupExists(int giftList, int group);
        GiftListGroup GetGiftListGroupById(int id);
        GiftListGroup GetGiftListGroup(int giftList, int group);
        long Insert(GiftListGroup giftListGroup);
        void Insert(List<GiftListGroup> batch);
        void Update(int id, GiftListGroup giftListGroup);
        void Update(List<GiftListGroup> batch);
        void Delete(int id);
        void Delete(List<int> batch);
    }
}
