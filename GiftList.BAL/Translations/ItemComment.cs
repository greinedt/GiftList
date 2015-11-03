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

            bl.ItemCommentId = data.itemCommentId;
            bl.ItemFK = data.itemFK;
            bl.CommentorFK = data.commentorFK;
            bl.CommentText = data.commentText;
            bl.IsHiddenFromOwner = data.isHiddenFromOwner;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

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
