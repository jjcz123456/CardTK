using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class SysUserWarVO
	{
        public long suwId;
		public long suwUserId;
		public CfgWarVO suwCfgWar;
		public int suwUserHp;
		public int suwIsPass;
		public int suwIsRecoverHp;
		/// 		
	}
}