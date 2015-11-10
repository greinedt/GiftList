using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class ItemStatus : Base2
    {
        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
