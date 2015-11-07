using System;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public class Group : Base2
    {
        private int _creatorFK;
        public int CreatorFK
        {
            get { return _creatorFK; }
            set
            {
                _creatorFK = value;
                try
                {
                    PersonBL bl = new PersonBL();
                    _creator = bl.GetById(value);
                }
                catch (Exception)
                {
                    _creator = null;
                }
            }
        }

        private Person _creator;
        public Person Creator
        {
            get { return _creator; }
            set
            {
                _creatorFK = value != null ? value.Id : -1;
                _creator = value;
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private bool _isPrivate;
        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
        }
    }
}
