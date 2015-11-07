using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static LinkBL Link(LinkEntity data)
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

        public static List<LinkBL> Link(List<LinkEntity> dataList)
        {
            List<LinkBL> blList = new List<LinkBL>();
            foreach (LinkEntity data in dataList)
            {
                blList.Add(Link(data));
            }
            return blList;
        }

        public static LinkEntity Link(LinkBL bl)
        {
            LinkEntity data = new LinkEntity();

            data.linkId = bl.LinkId;
            data.itemFK = bl.ItemFK;
            data.linkName = bl.LinkName;
            data.url = bl.Url;
            data.isImage = bl.IsImage;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<LinkEntity> Link(List<LinkBL> blList)
        {
            List<LinkEntity> dataList = new List<LinkEntity>();
            foreach (LinkBL bl in blList)
            {
                dataList.Add(Link(bl));
            }
            return dataList;
        }
    }
}
