using System;

namespace TheGiftList.BAL.Entities
{
    public class Person : Base
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _passwordHash;
        public string PasswordHash
        {
            get { return _passwordHash; }
            set { _passwordHash = value; }
        }
    }
}
