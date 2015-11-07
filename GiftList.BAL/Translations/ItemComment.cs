using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static ItemCommentBL ItemComment(ItemCommentEntity data)
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

        public static List<ItemCommentBL> ItemComment(List<ItemCommentEntity> dataList)
        {
            List<ItemCommentBL> blList = new List<ItemCommentBL>();
            foreach (ItemCommentEntity data in dataList)
            {
                blList.Add(ItemComment(data));
            }
            return blList;
        }

        public static ItemCommentEntity ItemComment(ItemCommentBL bl)
        {
            ItemCommentEntity data = new ItemCommentEntity();

            data.itemCommentId = bl.ItemCommentId;
            data.itemFK = bl.ItemFK;
            data.commentorFK = bl.CommentorFK;
            data.commentText = bl.CommentText;
            data.isHiddenFromOwner = bl.IsHiddenFromOwner;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<ItemCommentEntity> ItemComment(List<ItemCommentBL> blList)
        {
            List<ItemCommentEntity> dataList = new List<ItemCommentEntity>();
            foreach (ItemCommentBL bl in blList)
            {
                dataList.Add(ItemComment(bl));
            }
            return dataList;
        }
    }
}
