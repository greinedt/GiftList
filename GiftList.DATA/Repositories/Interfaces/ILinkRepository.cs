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
        IList<LinkEntity> GetAllLinks(IConnection conn);
        IList<LinkEntity> GetAllLinks(int item, IConnection conn);
        long GetNumberOfLinks(int item, IConnection conn);
        bool LinkExists(int item, string linkName, IConnection conn);
        LinkEntity GetLinkById(int id, IConnection conn);
        LinkEntity GetLink(int itemId, string linkName, IConnection conn);
        long Insert(LinkEntity link, IConnection conn);
        void Update(int id, LinkEntity link, IConnection conn);
        void Delete(int id, IConnection conn);
        void Insert(List<LinkEntity> batch, IConnection conn);
        void Update(List<LinkEntity> batch, IConnection conn);
        void Delete(List<int> batch, IConnection conn);
    }
}
