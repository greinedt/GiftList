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

            //ent.linkId = data.linkId;
            //ent.itemFK = data.itemFK;
            //ent.linkName = data.linkName;
            //ent.url = data.url;
            //ent.isImage = data.isImage;
            //ent.updateTimestamp = data.updateTimestamp;
            //ent.updatePersonFK = data.updatePersonFK;

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
