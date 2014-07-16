using System;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class SysUserUnionTaskVO
    {
        public long suntId;
        public long suntUnionId;
        public long suntUserId;
        public CfgUnionTaskVO cfgUnionTask;
        public int suntFinishNum;
        public int suntIsOver;
        public int suntIsGet;

    }
}