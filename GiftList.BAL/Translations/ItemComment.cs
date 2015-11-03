﻿using System;
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

        public static ItemComment ItemComment(ItemCommentBL bl)
        {
            ItemComment data = new ItemComment();

            data.itemCommentId = bl.ItemCommentId;
            data.itemFK = bl.ItemFK;
            data.commentorFK = bl.CommentorFK;
            data.commentText = bl.CommentText;
            data.isHiddenFromOwner = bl.IsHiddenFromOwner;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<ItemComment> ItemComment(List<ItemCommentBL> blList)
        {
            List<ItemComment> dataList = new List<ItemComment>();
            foreach (ItemCommentBL bl in blList)
            {
                dataList.Add(Translate.ItemComment(bl));
            }
            return dataList;
        }
    }
}
