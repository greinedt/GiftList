using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class GiftListGroupBL
    {
        #region BLProperties

        private int _giftLsitGroupId;
        public int GiftListGroupId
        {
            get { return _giftLsitGroupId; }
            set { _giftLsitGroupId = value; }
        }
        
        private int _giftListFK;
        public int GiftListFK
        {
            get { return _giftListFK; }
            set
            {
                _giftListFK = value;
                try
                {
                    _giftList = GiftListBL.GetById(value);
                }
                catch (Exception)
                {
                    _giftList = null;
                }
            }
        }

        private GiftListBL _giftList;
        public GiftListBL GiftList
        {
            get { return _giftList; }
            set
            {
                _giftListFK = value != null ? value.GiftListId : -1;
                _giftList = value;
            }
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

        public static GiftListGroupBL GetById(int id)
        {
            GiftListGroupRepository repo = new GiftListGroupRepository();
            return Translate.GiftListGroup(repo.GetGiftListGroupById(id));
        }

        #endregion BLMethods
    }
}
