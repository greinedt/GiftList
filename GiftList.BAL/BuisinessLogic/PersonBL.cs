using System;
using System.Collections.Generic;
using System.Linq;

using TheGiftList.DATA.Repositories;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    public class PersonBL : IPersonBL
    {
        private IPersonRepository repo;

        public PersonBL()
        {
            repo = new PersonRepository();
        }

        public List<Person> GetAll()
        {
            return Translate.Person(repo.GetAllPersons().ToList());
        }

        public Person GetPersonByUserName(string username)
        {
            return Translate.Person(repo.GetPersonByUserName(username));
        }

        public Person GetById(int id)
        {
            return  Translate.Person(repo.GetPersonById(id));
        }

        public bool Authenticate(string username, string password)
        {
            bool valid = false;
            Person person = GetPersonByUserName(username);
            if(person != null)
                valid = PasswordHashUtil.ValidatePassword(password, person.PasswordHash);
            return valid;
        }
    }
}
