using System;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class SysUserGeneralVO
    {
        public long sugId;
        public long sugUserId;
        public CfgGeneralLevelVO sugGeneralLevelVO;
        public int sugPos;
        public int sugExp;
        public CfgGeneralQualityVO cfgGeneralQualityVO;
        public int sugHp;
        public int sugAtk;
        public int sugUpgradeCount;
        public int sugNextRate;
        /// 
    }
}