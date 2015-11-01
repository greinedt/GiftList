using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TheGiftList.DATA.Entities;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static PersonBL Person(Person data)
        {
            PersonBL bl = new PersonBL();

            bl.PersonId = data.personId;
            bl.UserName = data.userName;
            bl.EmailAddress = data.emailAddress;
            bl.FirstName = data.firstName;
            bl.LastName = data.lastName;
            bl.PasswordHash = data.passwordHash;
            bl.UpdateTimestamp = data.updateTimestamp;

            return bl;
        }

        public static List<PersonBL> Person(List<Person> dataList)
        {
            List<PersonBL> blList = new List<PersonBL>();
            foreach(Person data in dataList)
            {
                blList.Add(Translate.Person(data));
            }
            return blList;
        }
    }
}
