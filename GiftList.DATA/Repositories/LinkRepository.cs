using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Link> GetAllLinks(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Link GetLink(int itemId, string linkName)
        {
            throw new NotImplementedException();
        }

        public Link GetLinkById(int id)
        {
            throw new NotImplementedException();
        }

        public long GetNumberOfLinks(string query)
        {
            throw new NotImplementedException();
        }

        public long Insert(Link Link)
        {
            throw new NotImplementedException();
        }

        public bool LinkExists(int itemId, string linkName)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Link link)
        {
            throw new NotImplementedException();
        }
    }
}
