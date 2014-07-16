using System;
using System.Collections.Generic;

namespace com.core.battle.round
{
    using Player = com.core.battle.player.Player;
    using PlayerMini = com.core.battle.player.PlayerMini;    

    [Serializable]
    public class OppositeDetailMf
    {

        public PlayerMini odmOr;
        public Pokerline pLine;
        public SkillOpt skillOpt;
        public OdmFactor odmFactor;
        public int hpMf;

        public int waterAtk; //ÔªËØ¹¥»÷
        public int fireAtk;
        public int woodAtk;
        public int lightAtk;
        public int darkAtk;

        public int fireMf;
        public int waterMf;
        public int woodMf;
        public List<PokerMf> pokerMfs;
        public List<long> triggerMajorSkills;
        public bool hasNext;
        public bool odmMain;
        public Player player;


    }

}