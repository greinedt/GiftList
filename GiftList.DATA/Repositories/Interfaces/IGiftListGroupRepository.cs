using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IGiftListGroupRepository
    {
        IList<GiftListGroup> GetAllGiftListGroups(string query, int page, int pageSize);
        long GetNumberOfGiftListGroups(string query);
        bool GiftListGroupExists(int giftList, int group);
        GiftListGroup GetGiftListGroupById(int id);
        GiftListGroup GetGiftListGroup(int giftList, int group);
        long Insert(GiftListGroup giftListGroup);
        void Update(int id, GiftListGroup giftListGroup);
        void Delete(int id);
    }
}
