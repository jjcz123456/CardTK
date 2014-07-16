using System;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class SysUserBackpackVO
    {
        public long subId;
        public long subUserId;
        public int subPos;
        public int subCount;
        public int subType;
        public long subTypeId;
        public int subIsUsed;
        public CfgGoodsVO cfgGoods;
        public SysUserEquipmentLevelVO sysUserEquipmentLevel;
        public SysUserSoulVO sysUserSoul;
        /// 
    }
}