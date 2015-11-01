using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.Link Link(TheGiftList.DATA.Entities.Link data)
        {
            Entities.Link ent = new Entities.Link();

            ent.linkId = data.linkId;
            ent.itemFK = data.itemFK;
            ent.linkName = data.linkName;
            ent.url = data.url;
            ent.isImage = data.isImage;
            ent.updateTimestamp = data.updateTimestamp;
            ent.updatePersonFK = data.updatePersonFK;

            return ent;
        }
    }
}
