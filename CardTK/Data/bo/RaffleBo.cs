using System;
using System.Collections.Generic;

namespace com.pokertk.data.bo
{


	using CfgRaffleCostVO = com.pokertk.data.vo.CfgRaffleCostVO;
	using CfgRewardItemVO = com.pokertk.data.vo.CfgRewardItemVO;

	[Serializable]
	public class RaffleBo
	{
        public CfgRaffleCostVO nextCost;
		public CfgRewardItemVO selected;
		public List<CfgRewardItemVO> rewards;


		
	}

}