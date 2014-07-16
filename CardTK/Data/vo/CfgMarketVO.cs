using System;
using System.Collections.Generic;

namespace com.pokertk.data.vo
{
	public class CfgMarketVO
	{
        public long cmId;
		public CfgMarketTypeVO cmTypeVO;
		public CfgMarketSubTypeVO cmSubTypeVO;
		public long cmCargoId;
		public int cmSn;
		public int cmPayNumber;
		public CfgMarketSubTypeVO cmReferTypeVO;
		public DateTime cmStart;
		public DateTime cmEnd;
		public List<CfgMarketPriceVO> cmPrices;
		public object cmCargoVO;
	}
}