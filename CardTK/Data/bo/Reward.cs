using System;
using System.Collections.Generic;

namespace com.pokertk.data.bo
{


	using CfgRewardItemVO = com.pokertk.data.vo.CfgRewardItemVO;

	[Serializable]
	public class Reward
	{

        public bool tip;
		public string tipMsg;
		public List<CfgRewardItemVO> rewardList;
		public int curExpStart;
		public int curExpTatal;
		public int curExp;
		public bool levelUp;
		public int finalExpStart;
		public int finalExpTatal;
		public int finalExp;
		public bool share;
		public int shareType;
		public int curLevel;
		public bool isGeneral;


	}

}