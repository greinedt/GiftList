using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class Item : Base2
    {
        private int _itemStatusFK;
        public int ItemStatusFK
        {
            get { return _itemStatusFK; }
            set
            {
                _itemStatusFK = value;
                try
                {
                    GroupBL bl = new GroupBL();
                    _itemStatus = bl.GetById(value);
                }
                catch (Exception)
                {
                    _itemStatus = null;
                }
            }
        }

        private Group _itemStatus;
        public Group ItemStatus
        {
            get { return _itemStatus; }
            set
            {
                _itemStatusFK = value != null ? value.Id : -1;
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
                    GiftListBL bl = new GiftListBL();
                    _giftList = bl.GetById(value);
                }
                catch (Exception)
                {
                    _giftList = null;
                }
            }
        }

        private GiftList _giftList;
        public GiftList GiftList
        {
            get { return _giftList; }
            set
            {
                _giftListFK = value != null ? value.Id : -1;
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
    }
}
