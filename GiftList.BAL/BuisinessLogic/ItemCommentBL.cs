using System;
using System.Collections.Generic;
using System.Linq;
using TheGiftList.BAL.Entities;
using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class ItemCommentBL : IItemCommentBL
    {
        private IItemCommentRepository repo;

        public ItemCommentBL()
        {
            repo = new ItemCommentRepository();
        }

        public ItemComment GetById(int id)
        {
            return Translate.ItemComment(repo.GetItemCommentById(id));
        }

        public List<ItemComment> GetAll()
        {
            return Translate.ItemComment(repo.GetAllItemComments().ToList());
        }
    }
}
