using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    internal static partial class Translate
    {
        internal static ItemComment ItemComment(ItemCommentEntity data)
        {
            ItemComment ent = new ItemComment();

            ent.Id = data.itemCommentId;
            ent.ItemFK = data.itemFK;
            ent.CommentorFK = data.commentorFK;
            ent.CommentText = data.commentText;
            ent.IsHiddenFromOwner = data.isHiddenFromOwner;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        internal static List<ItemComment> ItemComment(List<ItemCommentEntity> dataList)
        {
            List<ItemComment> entList = new List<ItemComment>();
            foreach (ItemCommentEntity data in dataList)
            {
                entList.Add(ItemComment(data));
            }
            return entList;
        }

        internal static ItemCommentEntity ItemComment(ItemComment ent)
        {
            ItemCommentEntity data = new ItemCommentEntity();

            data.itemCommentId = ent.Id;
            data.itemFK = ent.ItemFK;
            data.commentorFK = ent.CommentorFK;
            data.commentText = ent.CommentText;
            data.isHiddenFromOwner = ent.IsHiddenFromOwner;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        internal static List<ItemCommentEntity> ItemComment(List<ItemComment> entList)
        {
            List<ItemCommentEntity> dataList = new List<ItemCommentEntity>();
            foreach (ItemComment ent in entList)
            {
                dataList.Add(ItemComment(ent));
            }
            return dataList;
        }
    }
}
