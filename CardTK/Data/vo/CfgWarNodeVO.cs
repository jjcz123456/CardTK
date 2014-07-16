using System;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class CfgWarNodeVO
    {
        public long cwnId;
        public CfgWarVO cwnCfgWar;
        public string cwnName;
        public string cwnImage;
        public string cwnPos;
        public long cwnPreid;
        public long cwnPreid2;
        public string cwnLine;
        public string cwnLine2;
        public string cwnType;
        public long cwnTypeId;
        public CfgMonsterVO cfgMonster;
        public CfgWarBoxVO cfgWarBox;
        public CfgWarTrapVO cfgWarTrap;
        /// 
    }
}