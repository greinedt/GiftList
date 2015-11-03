using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;


namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GroupBL Group(Group data)
        {
            GroupBL bl = new GroupBL();

            bl.GroupId = data.groupId;
            bl.CreatorFK = data.creatorFK;
            bl.Description = data.description;
            bl.IsPrivate = data.isPrivate;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<GroupBL> Group(List<Group> dataList)
        {
            List<GroupBL> blList = new List<GroupBL>();
            foreach (Group data in dataList)
            {
                blList.Add(Translate.Group(data));
            }
            return blList;
        }

        public static Group Group(GroupBL bl)
        {
            Group data = new Group();

            data.groupId = bl.GroupId;
            data.creatorFK = bl.CreatorFK;
            data.description = bl.Description;
            data.isPrivate = bl.IsPrivate;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<Group> Group(List<GroupBL> blList)
        {
            List<Group> dataList = new List<Group>();
            foreach (GroupBL bl in blList)
            {
                dataList.Add(Translate.Group(bl));
            }
            return dataList;
        }
    }
}
