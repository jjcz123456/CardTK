using System;
using System.Collections.Generic;

namespace com.pokertk.data.bo
{   
    [Serializable]
    public class PkRoom
    {
        public int prId;
        public long createTime;
        public string prName;
        public string prPassword;
        public int prState;
        public int capacity;
        public int remaining;
        public long ownerId;
        public int ownerBattlePower;
        public List<PkSeat> seatList;

    }

}