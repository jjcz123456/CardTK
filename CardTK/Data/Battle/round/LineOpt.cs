using System;
using System.Collections.Generic;
using com.core.battle.player;

namespace com.core.battle.round
{

    [Serializable]
    public class LineOpt
    {
        public PlayerMini loOr;
        public List<PokerMf> pokerMfs;
        public List<Pokerline> pokerLines;
    }

}