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
        IList<PersonEntity> GetAllPersons(IConnection conn);
        IList<PersonEntity> GetAllPersonsLike(string partialUserName, IConnection conn);
        int GetNumberOfPersons(string partialUserName, IConnection conn);
        bool PersonExistsByEmail(string email, IConnection conn);
        bool PersonExistsByUserName(string userName, IConnection conn);
        PersonEntity GetPersonById(int id, IConnection conn);
        PersonEntity GetPersonByEmail(string email, IConnection conn);
        PersonEntity GetPersonByUserName(string userName, IConnection conn);
        int Insert(PersonEntity person, IConnection conn);
        void Update(int id, PersonEntity contact, IConnection conn);
        void Delete(int id, IConnection conn);
        void Insert(List<PersonEntity> batch, IConnection conn);
        void Update(List<PersonEntity> batch, IConnection conn);
        void Delete(List<int> batch, IConnection conn);
    }
}
