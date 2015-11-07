using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TheGiftList.DATA.Entities;
using TheGiftList.BAL.Entities;

namespace TheGiftList.BAL
{
    internal static partial class Translate
    {
        internal static Person Person(PersonEntity data)
        {
            Person ent = new Person();

            ent.Id = data.personId;
            ent.UserName = data.userName;
            ent.EmailAddress = data.emailAddress;
            ent.FirstName = data.firstName;
            ent.LastName = data.lastName;
            ent.PasswordHash = data.passwordHash;
            ent.UpdateTimestamp = data.updateTimestamp;

            return ent;
        }

        internal static List<Person> Person(List<PersonEntity> dataList)
        {
            List<Person> entList = new List<Person>();
            foreach(PersonEntity data in dataList)
            {
                entList.Add(Person(data));
            }
            return entList;
        }

        internal static PersonEntity Person(Person ent)
        {
            PersonEntity data = new PersonEntity();

            data.personId = ent.Id;
            data.userName = ent.UserName;
            data.emailAddress = ent.EmailAddress;
            data.firstName = ent.FirstName;
            data.lastName = ent.LastName;
            data.passwordHash = ent.PasswordHash;
            data.updateTimestamp = ent.UpdateTimestamp;

            return data;
        }

        internal static List<PersonEntity> Person(List<Person> entList)
        {
            List<PersonEntity> dataList = new List<PersonEntity>();
            foreach (Person ent in entList)
            {
                dataList.Add(Person(ent));
            }
            return dataList;
        }
    }
}
