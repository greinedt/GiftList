using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;


namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GroupBL Group(GroupEntity data)
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

        public static List<GroupBL> Group(List<GroupEntity> dataList)
        {
            List<GroupBL> blList = new List<GroupBL>();
            foreach (GroupEntity data in dataList)
            {
                blList.Add(Group(data));
            }
            return blList;
        }

        public static GroupEntity Group(GroupBL bl)
        {
            GroupEntity data = new GroupEntity();

            data.groupId = bl.GroupId;
            data.creatorFK = bl.CreatorFK;
            data.description = bl.Description;
            data.isPrivate = bl.IsPrivate;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<GroupEntity> Group(List<GroupBL> blList)
        {
            List<GroupEntity> dataList = new List<GroupEntity>();
            foreach (GroupBL bl in blList)
            {
                dataList.Add(Group(bl));
            }
            return dataList;
        }
    }
}
