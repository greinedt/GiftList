using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class Link : Base2
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

        private string _linkName;
        public string LinkName
        {
            get { return _linkName; }
            set { _linkName = value; }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private bool _isImage;
        public bool IsImage
        {
            get { return _isImage; }
            set { _isImage = value; }
        }
    }
}
