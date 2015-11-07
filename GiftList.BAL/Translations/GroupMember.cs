using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    internal static partial class Translate
    {
        internal static GroupMember GroupMember(GroupMemberEntity data)
        {
            GroupMember ent = new GroupMember();

            ent.Id = data.groupMemberId;
            ent.GroupFK = data.groupFK;
            ent.MemberFK = data.memberFK;
            ent.IsAdmin = data.isAdmin;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        internal static List<GroupMember> GroupMember(List<GroupMemberEntity> dataList)
        {
            List<GroupMember> entList = new List<GroupMember>();
            foreach (GroupMemberEntity data in dataList)
            {
                entList.Add(GroupMember(data));
            }
            return entList;
        }

        internal static GroupMemberEntity GroupMember(GroupMember ent)
        {
            GroupMemberEntity data = new GroupMemberEntity();

            data.groupMemberId = ent.Id;
            data.groupFK = ent.GroupFK;
            data.memberFK = ent.MemberFK;
            data.isAdmin = ent.IsAdmin;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        internal static List<GroupMemberEntity> GroupMember(List<GroupMember> entList)
        {
            List<GroupMemberEntity> dataList = new List<GroupMemberEntity>();
            foreach (GroupMember ent in entList)
            {
                dataList.Add(GroupMember(ent));
            }
            return dataList;
        }
    }
}
