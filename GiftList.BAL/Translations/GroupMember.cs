using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static GroupMemberBL GroupMember(GroupMember data)
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

        public static List<GroupMemberBL> GroupMember(List<GroupMember> dataList)
        {
            List<GroupMemberBL> blList = new List<GroupMemberBL>();
            foreach (GroupMember data in dataList)
            {
                blList.Add(Translate.GroupMember(data));
            }
            return blList;
        }
    }
}
