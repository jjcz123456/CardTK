using System;
using System.Collections.Generic;

namespace com.pokertk.data.vo
{


	[Serializable]
	public class CfgUnionMarketVO
	{
        
        public int cumId;
		public int cumUnionBuildMarketId;
		public string cumType;
		public int cumTypeId;
		public int cumSn;
		public DateTime cumStart;
		public DateTime cumEnd;
		public List<CfgUnionMarketPriceVO> priceList;
		public CfgGoodsVO cfgGoodsVO;
		public CfgEquipmentLevelVO cfgEquipmentLevelVO;
		public CfgGeneralLevelVO cfgGeneralLevelVO;
        
	}
}