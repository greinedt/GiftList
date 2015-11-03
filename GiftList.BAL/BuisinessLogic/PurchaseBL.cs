using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class PurchaseBL
    {
        #region BLProperties

        private int _purchaseId;
        public int PurchaseId
        {
            get { return _purchaseId; }
            set { _purchaseId = value; }
        }

        private int _itemFK;
        public int ItemFK
        {
            get { return _itemFK; }
            set
            {
                _itemFK = value;
                try
                {
                    _item = GroupBL.GetById(value);
                }
                catch (Exception)
                {
                    _item = null;
                }
            }
        }

        private GroupBL _item;
        public GroupBL Item
        {
            get { return _item; }
            set
            {
                _itemFK = value != null ? value.GroupId : -1;
                _item = value;
            }
        }

        private int _purchaserFK;
        public int PurchaserFK
        {
            get { return _purchaserFK; }
            set
            {
                _purchaserFK = value;
                try
                {
                    _purchaser = PersonBL.GetById(value);
                }
                catch (Exception)
                {
                    _purchaser = null;
                }
            }
        }

        private PersonBL _purchaser;
        public PersonBL Purchaser
        {
            get { return _purchaser; }
            set
            {
                _purchaserFK = value != null ? value.PersonId : -1;
                _purchaser = value;
            }
        }

        private DateTime? _purchaseDate;
        public DateTime? PurchaseDate
        {
            get { return _purchaseDate; }
            set { _purchaseDate = value; }
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

        public static PurchaseBL GetById(int id)
        {
            PurchaseRepository repo = new PurchaseRepository();
            return Translate.Purchase(repo.GetPurchaseById(id));
        }

        #endregion BLMethods
    }
}
