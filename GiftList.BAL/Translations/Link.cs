using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static LinkBL Link(Link data)
        {
            LinkBL bl = new LinkBL();

            bl.LinkId = data.linkId;
            bl.ItemFK = data.itemFK;
            bl.LinkName = data.linkName;
            bl.Url = data.url;
            bl.IsImage = data.isImage;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<LinkBL> Link(List<Link> dataList)
        {
            List<LinkBL> blList = new List<LinkBL>();
            foreach (Link data in dataList)
            {
                blList.Add(Translate.Link(data));
            }
            return blList;
        }
    }
}
