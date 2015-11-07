using System.Collections.Generic;
using TheGiftList.DATA.Entities;

namespace TheGiftList.DATA.Repositories
{
    public interface IPersonRepository
    {
        IList<PersonEntity> GetAllPersons();
        IList<PersonEntity> GetAllPersonsLike(string partialUserName);
        int GetNumberOfPersons(string partialUserName);
        bool PersonExistsByEmail(string email);
        bool PersonExistsByUserName(string userName);
        PersonEntity GetPersonById(int id);
        PersonEntity GetPersonByEmail(string email);
        PersonEntity GetPersonByUserName(string userName);
        int Insert(PersonEntity person);
        void Update(int id, PersonEntity contact);
        void Delete(int id);
        void Insert(List<PersonEntity> batch);
        void Update(List<PersonEntity> batch);
        void Delete(List<int> batch);
    }
}
