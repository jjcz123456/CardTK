using System;
using System.Collections.Generic;
using com.core.battle.board;
using com.core.battle.player;

namespace com.core.battle.round
{

    [Serializable]
    public class HalfRound
    {
        public bool gameOver;
        public int wheel;
        public int round;
        public int thinkMax;
        public Opt lastOpt;
        public List<DetailMf> detailMfs;
        public List<Poker> boardPokers;
        public Player atk;
        public Player def;

    }

}