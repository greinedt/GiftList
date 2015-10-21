using System.Collections.Generic;
using GiftList.DATA.Entities;

namespace GiftLink.DATA.Repositories
{
    public interface ILinkRepository
    {
        IList<Link> GetAllLinks(string query, int page, int pageSize);
        long GetNumberOfLinks(string query);
        bool LinkExists(int itemId, string linkName);
        Link GetLinkById(int id);
        Link GetLink(int itemId, string linkName);
        long Insert(Link Link);
        void Update(int id, Link link);
        void Delete(int id);
    }
}
