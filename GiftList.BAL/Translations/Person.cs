using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGiftList.BAL
{
    public static partial class Translate
    {
        public static TheGiftList.BAL.Entities.Person Person(TheGiftList.DATA.Entities.Person data)
        {
            Entities.Person bal = new Entities.Person();

            bal.personId = data.personId;
            bal.userName = data.userName;
            bal.emailAddress = data.emailAddress;
            bal.firstName = data.firstName;
            bal.lastName = data.lastName;
            bal.passwordHash = data.passwordHash;
            bal.updateTimestamp = data.updateTimestamp;

            return bal;
        }
    }
}
