using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class GiftListGroup : Base2
    {
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
    }
}
