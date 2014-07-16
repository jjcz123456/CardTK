using System;
using System.Collections.Generic;

namespace com.core.battle.bo
{


    using PlayerMini = com.core.battle.player.PlayerMini;
    using HalfRound = com.core.battle.round.HalfRound;

    public class ReplayBo
    {
        public int count;
        public string id;
        public PlayerMini winner;
        public int battleType;
        public int resultType;
        public List<HalfRound> rounds;
        public object rewardMap;

    }

}