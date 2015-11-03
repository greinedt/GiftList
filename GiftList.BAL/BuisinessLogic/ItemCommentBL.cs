using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class ItemCommentBL
    {
        #region BLProperties

        private int _itemCommentId;
        public int ItemCommentId
        {
            get { return _itemCommentId; }
            set { _itemCommentId = value; }
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

        private int _commentorFK;
        public int CommentorFK
        {
            get { return _commentorFK; }
            set
            {
                _commentorFK = value;
                try
                {
                    _commentor = PersonBL.GetById(value);
                }
                catch (Exception)
                {
                    _commentor = null;
                }
            }
        }

        private PersonBL _commentor;
        public PersonBL Commentor
        {
            get { return _commentor; }
            set
            {
                _commentorFK = value != null ? value.PersonId : -1;
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
