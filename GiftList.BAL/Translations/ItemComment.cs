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
            Entities.ItemComment bal = new Entities.ItemComment();

            bal.itemCommentId = data.itemCommentId;
            bal.itemFK = data.itemFK;
            bal.commentorFK = data.commentorFK;
            bal.commentText = data.commentText;
            bal.isHiddenFromOwner = data.isHiddenFromOwner;
            bal.updateTimeStamp = data.updateTimeStamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
