using System;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class SysUserUnionVO
    {
        public long sunId;
        public SysUnionVO sysUnion;
        public SysUserVO sysUser;
        public CfgUnionPowerVO cfgUnionPower;
        public int sunDevote;
        public int sunTotalDevote;
        public int sunLeftDonateSilver;
        public int sunGetTaskReward;
    }
}