using System;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class SysUserSuitVO
    {
        public long susuitId;
        public long susuitUserId;
        public CfgSuitVO susuitSuitVO;
        public CfgSuitLevelVO susuitSuitLevelVO;
        public int susuitUsed;
        public int susuitIsLeaf;
        /// 
    }
}