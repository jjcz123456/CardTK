using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class SysUserCorpsVO
	{
        public long sucId;
		public long sucUserId;
		public CfgCorpsLevelVO sucCorpsLevelVO;
		public int sucUsed;
        public int sucState;
	}
}