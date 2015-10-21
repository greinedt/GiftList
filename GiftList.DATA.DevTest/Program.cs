using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftList.DATA.Repositories;
using GiftList.DATA.Entities;

namespace GiftList.DATA.DevTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository repo = new PersonRepository();
            repo.GetNumberOfPersons("dd");
            repo.GetAllPersonsLike("");
            repo.GetPersonByEmail("admin@admin.admin");
            repo.GetPersonById(1);
            repo.GetPersonByUserName("admin");
            repo.PersonExistsByEmail("admin@admin.admin");
            repo.PersonExistsByUserName("admin");
            Person p = new Person()
            {
                userName = "a",
                emailAddress = "a"
            };
            int id = repo.Insert(p);
            p.lastName = "a";
            repo.Update(id, p);
            repo.Delete(id);
        }
    }
}
