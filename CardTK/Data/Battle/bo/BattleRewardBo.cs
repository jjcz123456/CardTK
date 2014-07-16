using com.common.socket.vo;
using com.pokertk.data.bo;
using System.Collections.Generic;

namespace com.core.battle.bo
{
	

	/// <summary>
	/// 战斗奖励
	/// </summary>
	public class BattleRewardBo
	{
        public long userId;
		public Reward reward;
		public List<NotifyVO> notifyList;
		public RaffleBo raffle;

	}

}