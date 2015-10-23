using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IPersonRepository
    {
        IList<Person> GetAllPersonsLike(string partialUserName);
        int GetNumberOfPersons(string partialUserName);
        bool PersonExistsByEmail(string email);
        bool PersonExistsByUserName(string userName);
        Person GetPersonById(int id);
        Person GetPersonByEmail(string email);
        Person GetPersonByUserName(string userName);
        int Insert(Person person);
        void Update(int id, Person contact);
        void Delete(int id);
    }
}
