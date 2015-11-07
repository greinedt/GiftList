using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class ItemComment : Base2
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

        private int _commentorFK;
        public int CommentorFK
        {
            get { return _commentorFK; }
            set
            {
                _commentorFK = value;
                try
                {
                    PersonBL bl = new PersonBL();
                    _commentor = bl.GetById(value);
                }
                catch (Exception)
                {
                    _commentor = null;
                }
            }
        }

        private Person _commentor;
        public Person Commentor
        {
            get { return _commentor; }
            set
            {
                _commentorFK = value != null ? value.Id : -1;
                _commentor = value;
            }
        }

        private string _commentText;
        public string CommentText
        {
            get { return _commentText; }
            set { _commentText = value; }
        }

        private bool _isHiddenFromOwner;
        public bool IsHiddenFromOwner
        {
            get { return _isHiddenFromOwner; }
            set { _isHiddenFromOwner = value; }
        }
    }
}
