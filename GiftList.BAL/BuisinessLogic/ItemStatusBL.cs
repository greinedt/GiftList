using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class ItemStatusBL
    {
        #region BLProperties

        private int _itemStatusId;
        public int ItemStatusId
        {
            get { return _itemStatusId; }
            set { _itemStatusId = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
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

        public static ItemStatusBL GetById(int id)
        {
            ItemStatusRepository repo = new ItemStatusRepository();
            return Translate.ItemStatus(repo.GetItemStatusById(id));
        }

        #endregion BLMethods
    }
}
