using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class Purchase : Base2
    {
        private int _itemFK;
        public int ItemFK
        {
            get { return _itemFK; }
            set
            {
                _itemFK = value;
                try
                {
                    GroupBL bl = new GroupBL();
                    _item = bl.GetById(value);
                }
                catch (Exception)
                {
                    _item = null;
                }
            }
        }

        private Group _item;
        public Group Item
        {
            get { return _item; }
            set
            {
                _itemFK = value != null ? value.Id : -1;
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
                    PersonBL bl = new PersonBL();
                    _purchaser = bl.GetById(value);
                }
                catch (Exception)
                {
                    _purchaser = null;
                }
            }
        }

        private Person _purchaser;
        public Person Purchaser
        {
            get { return _purchaser; }
            set
            {
                _purchaserFK = value != null ? value.Id : -1;
                _purchaser = value;
            }
        }

        private DateTime? _purchaseDate;
        public DateTime? PurchaseDate
        {
            get { return _purchaseDate; }
            set { _purchaseDate = value; }
        }
    }
}
