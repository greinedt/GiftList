using System;
using System.Collections.Generic;
using System.Linq;
using TheGiftList.BAL.Entities;
using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class LinkBL : ILinkBL
    {
        private ILinkRepository repo;

        public LinkBL()
        {
            repo = new LinkRepository();
        }

        public Link GetById(int id)
        {
            return Translate.Link(repo.GetLinkById(id));
        }

        public List<Link> GetAll()
        {
            return Translate.Link(repo.GetAllLinks().ToList());
        }
    }
}
