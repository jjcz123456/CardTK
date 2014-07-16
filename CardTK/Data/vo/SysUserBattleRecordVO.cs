using System;

namespace com.pokertk.data.vo
{


	[Serializable]
	public class SysUserBattleRecordVO
	{
        public long subrId;
		public int subrType;
		public long subrUserId;
		public long subrOppoId;
		public int subrWin;
		public string subrReplayId;
		public DateTime subrTime;
		public int subrUnexpected;
	}
}