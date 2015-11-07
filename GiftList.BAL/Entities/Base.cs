using System;

namespace TheGiftList.BAL.Entities
{
    public abstract class Base
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private DateTime _updateTimestamp;
        public DateTime UpdateTimestamp
        {
            get { return _updateTimestamp; }
            set { _updateTimestamp = value; }
        }
    }
}
