using System;
using System.Collections.Generic;

namespace com.pokertk.data.vo
{
	[Serializable]
	public class CfgGiftVO
	{
        public long cgiId;
		public string cgiName;
		public string cgiType;
		public long cgiTypeItem;
		public int cgiOods;
		public long cgiNextGiftId;
		public List<CfgRewardItemVO> rewards;

	}
}