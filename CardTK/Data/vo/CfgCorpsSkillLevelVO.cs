using System;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class CfgCorpsSkillLevelVO
    {
        public long ccslId;
        public CfgCorpsSkillVO ccslSkillVO;
        public long ccslNextId;
        public int ccslLevel;
        public int ccslOdds;
        public int ccslNextOdds;
        public int ccslUpgradValue;
    }
}