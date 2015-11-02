using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class GroupBL
    {
        #region BLProperties

        private int _groupId;
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private int _creatorFK;
        public int CreatorFK
        {
            get { return _creatorFK; }
            set
            {
                _creatorFK = value;
                try
                {
                    _creator = PersonBL.GetById(value);
                }
                catch (Exception e)
                {
                    _creator = null;
                }
            }
        }

        private PersonBL _creator;
        public PersonBL Creator
        {
            get { return _creator; }
            set
            {
                _creatorFK = value != null ? value.PersonId : -1;
                _creator = value;
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private bool _isPrivate;
        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
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
                catch (Exception e)
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

        public GroupBL GetByID(int id)
        {
            GroupRepository repo = new GroupRepository();
            return Translate.GiftList(repo.GetGroupById(id));
        }

        #endregion BLMethods

    }
}
