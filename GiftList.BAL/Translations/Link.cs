using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static Link Link(LinkEntity data)
        {
            Link ent = new Link();

            ent.Id = data.linkId;
            ent.ItemFK = data.itemFK;
            ent.LinkName = data.linkName;
            ent.Url = data.url;
            ent.IsImage = data.isImage;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        public static List<Link> Link(List<LinkEntity> dataList)
        {
            List<Link> entList = new List<Link>();
            foreach (LinkEntity data in dataList)
            {
                entList.Add(Link(data));
            }
            return entList;
        }

        public static LinkEntity Link(Link ent)
        {
            LinkEntity data = new LinkEntity();

            data.linkId = ent.Id;
            data.itemFK = ent.ItemFK;
            data.linkName = ent.LinkName;
            data.url = ent.Url;
            data.isImage = ent.IsImage;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        public static List<LinkEntity> Link(List<Link> entList)
        {
            List<LinkEntity> dataList = new List<LinkEntity>();
            foreach (Link ent in entList)
            {
                dataList.Add(Link(ent));
            }
            return dataList;
        }
    }
}
