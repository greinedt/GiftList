using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class GroupMember : Base2
    {
        private int _groupFK;
        public int GroupFK
        {
            get { return _groupFK; }
            set
            {
                _groupFK = value;
                try
                {
                    GroupBL bl = new GroupBL();
                    _group = bl.GetById(value);
                }
                catch (Exception)
                {
                    _group = null;
                }
            }
        }

        private Group _group;
        public Group Group
        {
            get { return _group; }
            set
            {
                _groupFK = value != null ? value.Id : -1;
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
                    PersonBL bl = new PersonBL();
                    _member = bl.GetById(value);
                }
                catch (Exception)
                {
                    _member = null;
                }
            }
        }

        private Person _member;
        public Person Member
        {
            get { return _member; }
            set
            {
                _memberFK = value != null ? value.Id : -1;
                _member = value;
            }
        }

        private bool _isAdmin;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
    }
}
