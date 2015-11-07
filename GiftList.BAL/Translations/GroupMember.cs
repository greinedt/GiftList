using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GroupMemberBL GroupMember(GroupMemberEntity data)
        {
            GroupMemberBL bl = new GroupMemberBL();

            bl.GroupMemberId = data.groupMemberId;
            bl.GroupFK = data.groupFK;
            bl.MemberFK = data.memberFK;
            bl.IsAdmin = data.isAdmin;
            bl.UpdateTimestamp = data.updateTimestamp;
            bl.UpdatePersonFK = data.updatePersonFK;

            return bl;
        }

        public static List<GroupMemberBL> GroupMember(List<GroupMemberEntity> dataList)
        {
            List<GroupMemberBL> blList = new List<GroupMemberBL>();
            foreach (GroupMemberEntity data in dataList)
            {
                blList.Add(GroupMember(data));
            }
            return blList;
        }

        public static GroupMemberEntity GroupMember(GroupMemberBL bl)
        {
            GroupMemberEntity data = new GroupMemberEntity();

            data.groupMemberId = bl.GroupMemberId;
            data.groupFK = bl.GroupFK;
            data.memberFK = bl.MemberFK;
            data.isAdmin = bl.IsAdmin;
            data.updateTimestamp = bl.UpdateTimestamp;
            data.updatePersonFK = bl.UpdatePersonFK;

            return data;
        }

        public static List<GroupMemberEntity> GroupMember(List<GroupMemberBL> blList)
        {
            List<GroupMemberEntity> dataList = new List<GroupMemberEntity>();
            foreach (GroupMemberBL bl in blList)
            {
                dataList.Add(GroupMember(bl));
            }
            return dataList;
        }
    }
}
