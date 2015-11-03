using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class ItemBL
    {
        #region BLProperties

        private int _itemId;
        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        private int _itemStatudFK;
        public int ItemStatusFK
        {
            get { return _itemStatudFK; }
            set
            {
                _itemStatudFK = value;
                try
                {
                    _itemStatus = GroupBL.GetById(value);
                }
                catch (Exception)
                {
                    _itemStatus = null;
                }
            }
        }

        private GroupBL _itemStatus;
        public GroupBL ItemStatus
        {
            get { return _itemStatus; }
            set
            {
                _itemStatudFK = value != null ? value.GroupId : -1;
                _itemStatus = value;
            }
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

        private string _itemName;
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
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

        public static ItemBL GetById(int id)
        {
            ItemRepository repo = new ItemRepository();
            return Translate.Item(repo.GetItemById(id));
        }

        #endregion BLMethods
    }
}
