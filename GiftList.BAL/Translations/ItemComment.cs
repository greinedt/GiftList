using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static ItemCommentBL ItemComment(ItemComment data)
        {
            ItemCommentBL bl = new ItemCommentBL();

            //ent.itemCommentId = data.itemCommentId;
            //ent.itemFK = data.itemFK;
            //ent.commentorFK = data.commentorFK;
            //ent.commentText = data.commentText;
            //ent.isHiddenFromOwner = data.isHiddenFromOwner;
            //ent.updateTimeStamp = data.updateTimeStamp;
            //ent.updatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<ItemCommentBL> ItemComment(List<ItemComment> dataList)
        {
            List<ItemCommentBL> blList = new List<ItemCommentBL>();
            foreach (ItemComment data in dataList)
            {
                blList.Add(Translate.ItemComment(data));
            }
            return blList;
        }
    }
}
