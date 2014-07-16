using System;
using System.Collections.Generic;

namespace com.pokertk.data.vo
{


	[Serializable]
	public class CfgExchangeVO
	{
        public long cecId;
		public string cecType;
		public long cecCfgId;
		public int cecNumber;
		public long cecTargetId;
		public object cfgVO;
		public List<CfgExchangeVO> cecSources;
	}
}