using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGiftList.BAL.BuisinessLogic;

namespace TheGiftList.BAL.Entities
{
    public abstract class Base2 : Base
    {
        private int _updatePersonFK;
        public int UpdatePersonFK
        {
            get { return _updatePersonFK; }
            set
            {
                _updatePersonFK = value;
                try
                {
                    PersonBL bl = new PersonBL();
                    _updatePerson = bl.GetById(value);
                }
                catch (Exception)
                {
                    _updatePerson = null;
                }
            }
        }

        private Person _updatePerson;
        public Person UpdatePerson
        {
            get { return _updatePerson; }
            set
            {
                _updatePersonFK = value != null ? value.Id : -1;
                _updatePerson = value;
            }
        }
    }
}
