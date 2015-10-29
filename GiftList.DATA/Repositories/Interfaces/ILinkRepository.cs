using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface ILinkRepository
    {
        IList<Link> GetAllLinks();
        IList<Link> GetAllLinks(int item);
        long GetNumberOfLinks(int item);
        bool LinkExists(int item, string linkName);
        Link GetLinkById(int id);
        Link GetLink(int itemId, string linkName);
        long Insert(Link link);
        void Update(int id, Link link);
        void Delete(int id);
        void Insert(List<Link> batch);
        void Update(List<Link> batch);
        void Delete(List<int> batch);
    }
}
