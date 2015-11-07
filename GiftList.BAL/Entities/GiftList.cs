using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class GiftList : Base2
    {
        private int _personFK;
        public int PersonFK
        {
            get { return _personFK; }
            set
            {
                _personFK = value;
                try
                {
                    PersonBL bl = new PersonBL();
                    _person = bl.GetById(value);
                }
                catch (Exception)
                {
                    _person = null;
                }
            }
        }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {
                _personFK = value != null ? value.Id : -1;
                _person = value;
            }
        }

        private string _listName;
        public string ListName
        {
            get { return _listName; }
            set { _listName = value; }
        }

        private bool _isPrivate;
        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
        }
    }
}
