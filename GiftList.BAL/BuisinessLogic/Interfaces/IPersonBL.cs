using System.Collections.Generic;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL.BuisinessLogic
{
    interface IPersonBL
    {
        List<Person> GetAll();
        Person GetPersonByUserName(string username);
        Person GetById(int id);
        bool Authenticate(string username, string password);
    }
}
