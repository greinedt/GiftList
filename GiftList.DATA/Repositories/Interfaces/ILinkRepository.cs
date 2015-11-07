using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface ILinkRepository
    {
        IList<LinkEntity> GetAllLinks();
        IList<LinkEntity> GetAllLinks(int item);
        long GetNumberOfLinks(int item);
        bool LinkExists(int item, string linkName);
        LinkEntity GetLinkById(int id);
        LinkEntity GetLink(int itemId, string linkName);
        long Insert(LinkEntity link);
        void Update(int id, LinkEntity link);
        void Delete(int id);
        void Insert(List<LinkEntity> batch);
        void Update(List<LinkEntity> batch);
        void Delete(List<int> batch);
    }
}
