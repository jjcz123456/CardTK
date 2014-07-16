using System;
using System.Collections.Generic;

namespace com.pokertk.data.vo
{


	[Serializable]
	public class CfgWarBoxVO
	{
        public long cwbId;
		public int cwbOne;
		public int cwbOneOdds;
		public int cwbTwo;
		public int cwbTwoOdds;
		public int cwbThree;
		public int cwbThreeOdds;
		public List<CfgRewardItemVO> rewardOneList;
		public List<CfgRewardItemVO> rewardTwoList;
		public List<CfgRewardItemVO> rewardThreeList;

		/// 
	}
}