using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class LinkBL
    {
        #region BLProperties

        private int _linkId;
        public int LinkId
        {
            get { return _linkId; }
            set { _linkId = value; }
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
