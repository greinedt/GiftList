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
            Entities.Link bal = new Entities.Link();

            bal.linkId = data.linkId;
            bal.itemFK = data.itemFK;
            bal.linkName = data.linkName;
            bal.url = data.url;
            bal.isImage = data.isImage;
            bal.updateTimestamp = data.updateTimestamp;
            bal.updatePersonFK = data.updatePersonFK;

            return bal;
        }
    }
}
