using System;
using System.Collections.Generic;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;


namespace TheGiftList.BAL
{
    internal static partial class Translate
    {
        internal static Group Group(GroupEntity data)
        {
            Group ent = new Group();

            ent.Id = data.groupId;
            ent.CreatorFK = data.creatorFK;
            ent.Description = data.description;
            ent.IsPrivate = data.isPrivate;
            ent.UpdateTimestamp = data.updateTimestamp;
            ent.UpdatePersonFK = data.updatePersonFK;

            return ent;
        }

        internal static List<Group> Group(List<GroupEntity> dataList)
        {
            List<Group> entList = new List<Group>();
            foreach (GroupEntity data in dataList)
            {
                entList.Add(Group(data));
            }
            return entList;
        }

        internal static GroupEntity Group(Group ent)
        {
            GroupEntity data = new GroupEntity();

            data.groupId = ent.Id;
            data.creatorFK = ent.CreatorFK;
            data.description = ent.Description;
            data.isPrivate = ent.IsPrivate;
            data.updateTimestamp = ent.UpdateTimestamp;
            data.updatePersonFK = ent.UpdatePersonFK;

            return data;
        }

        internal static List<GroupEntity> Group(List<Group> entList)
        {
            List<GroupEntity> dataList = new List<GroupEntity>();
            foreach (Group ent in entList)
            {
                dataList.Add(Group(ent));
            }
            return dataList;
        }
    }
}
