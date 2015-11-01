using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.ItemComment ItemComment(TheGiftList.DATA.Entities.ItemComment data)
        {
            Entities.ItemComment ent = new Entities.ItemComment();

            ent.itemCommentId = data.itemCommentId;
            ent.itemFK = data.itemFK;
            ent.commentorFK = data.commentorFK;
            ent.commentText = data.commentText;
            ent.isHiddenFromOwner = data.isHiddenFromOwner;
            ent.updateTimeStamp = data.updateTimeStamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
