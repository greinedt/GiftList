using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGiftList.DATA.Repositories;
using TheGiftList.DATA.Entities;
using TheGiftList.BAL;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class PersonBL
    {

        #region BLProperties

        private int _personId;
        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }

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

        private DateTime _updateTimestamp;
        public DateTime UpdateTimestamp
        {
            get { return _updateTimestamp; }
            set { _updateTimestamp = value; }
        }

        #endregion BLProperties

        #region BLMethods

        public static List<PersonBL> GetAllPersons()
        {
            PersonRepository repo = new PersonRepository();
            return Translate.Person(repo.GetAllPersons().ToList());
        }

        public static PersonBL GetPersonByUserName(string username)
        {
            PersonRepository repo = new PersonRepository();
            return Translate.Person(repo.GetPersonByUserName(username));
        }

        public static bool Authenticate(string username, string password)
        {
            PersonBL person = GetPersonByUserName(username);
            return TheGiftList.BAL.BuisinessLogic.PasswordHash.ValidatePassword(password, person.PasswordHash);
        }

        #endregion BLMethods
    }
}
