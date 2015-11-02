using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;


namespace TheGiftList.BAL.BuisinessLogic
{
    public class GiftListBL
    {
        #region BLProperties

        private int _giftListId;
        public int  GiftListId
        {
            get { return _giftListId; }
            set { _giftListId = value; }
        }

        private int _personFK;
        public int PersonFK
        {
            get { return _personFK; }
            set {
                _personFK = value;
                try
                {
                    _person = PersonBL.GetById(value);
                }
                catch (Exception e)
                {
                    _person = null;
                }
            }
        }

        private PersonBL _person;
        public PersonBL Person
        {
            get { return _person; }
            set {
                _personFK = value.PersonId;
                _person = value;
            }
        }

        private string _listName;
        public string ListName
        {
            get { return _listName; }
            set { _listName = value; }
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
            set {
                _updatePersonFK = value;
                try {
                    _updatePerson = PersonBL.GetById(value);
                } catch(Exception e)
                {
                    _updatePerson = null;
                }
            }
        }

        private PersonBL _updatePerson;
        public PersonBL UpdatePerson
        {
            get { return _updatePerson; }
            set {
                _updatePersonFK = value.PersonId;
                _updatePerson = value;
            }
        }

        #endregion BLProperties


        #region BLMethods  
        
        public GiftListBL GetByID(int id)
        {
            GiftListRepository repo = new GiftListRepository();
            return Translate.GiftList(repo.GetListById(id));
        }
              
        #endregion BLMethods
    }
}
