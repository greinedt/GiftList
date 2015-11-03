using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class GroupMemberBL
    {
        #region BLProperties

        private int _groupMemberId;
        public int GroupMemberId
        {
            get { return _groupMemberId; }
            set { _groupMemberId = value; }
        }

        private int _groupFK;
        public int GroupFK
        {
            get { return _groupFK; }
            set
            {
                _groupFK = value;
                try
                {
                    _group = GroupBL.GetById(value);
                }
                catch (Exception)
                {
                    _group = null;
                }
            }
        }

        private GroupBL _group;
        public GroupBL Group
        {
            get { return _group; }
            set
            {
                _groupFK = value != null ? value.GroupId : -1;
                _group = value;
            }
        }

        private int _memberFK;
        public int MemberFK
        {
            get { return _memberFK; }
            set
            {
                _memberFK = value;
                try
                {
                    _member = PersonBL.GetById(value);
                }
                catch (Exception)
                {
                    _member = null;
                }
            }
        }

        private PersonBL _member;
        public PersonBL Member
        {
            get { return _member; }
            set
            {
                _memberFK = value != null ? value.PersonId : -1;
                _member = value;
            }
        }

        private bool _isAdmin;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        private DateTime _updateTimestamp;
        public DateTime UpdateTimestamp
        {
            get { return _updateTimestamp; }
            set { _updateTimestamp = value; }
        }

        private int _updatePersonFK;
        public int UpdatePersonFK
        {
            get { return _updatePersonFK; }
            set
            {
                _updatePersonFK = value;
                try
                {
                    _updatePerson = PersonBL.GetById(value);
                }
                catch (Exception)
                {
                    _updatePerson = null;
                }
            }
        }

        private PersonBL _updatePerson;
        public PersonBL UpdatePerson
        {
            get { return _updatePerson; }
            set
            {
                _updatePersonFK = value != null ? value.PersonId : -1;
                _updatePerson = value;
            }
        }



        #endregion BLProperties


        #region BLMethods  

        public static GroupMemberBL GetById(int id)
        {
            GroupMemberRepository repo = new GroupMemberRepository();
            return Translate.GroupMember(repo.GetGroupMemberById(id));
        }

        #endregion BLMethods
    }
}
