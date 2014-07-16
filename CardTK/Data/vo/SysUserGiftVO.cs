using System;

namespace com.pokertk.data.vo
{


	[Serializable]
	public class SysUserGiftVO
	{
        public long sugiId;
		public long sugiUserId;
		public int sugiDailyLoginNum;
		public DateTime sugiDailyFirstLoginTime;
		public int sugiDailyLoginIsRecord;
		public int sugiDailyLotteryNum;
		public long sugiDailyGiftOne;
		public long sugiDailyGiftTwo;
		public long sugiDailyGiftThree;
		public int sugiDailyGiftOnePos;
		public int sugiDailyGiftTwoPos;
		public int sugiDailyGiftThreePos;
		public int sugiTitleGiftIsGet;
		public long sugiOnlineGiftId;
		public DateTime sugiOnlineGiftStartTime;
		public int sugiOnlineGiftCountTime;
		public int sugiOnlineGiftDesignTime;
		public int sugiOnlineGiftIsOver;
		public int sugiQqNewIsGet;
		public int sugiQqDailyIsGet;

	}
}