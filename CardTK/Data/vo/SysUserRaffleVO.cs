using System;

namespace com.pokertk.data.vo
{

	public class SysUserRaffleVO
	{
        public long surId;
		public long surUserId;
		public string surType;
		public int surNo;
		public int surOpened;
		public int surAwarded;
		public DateTime surTime;
		public CfgRewardItemVO surRewardVO;

	}
}