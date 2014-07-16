using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgRewardItemVO
	{      
        public long criId;
		public string criCfgType;
		public string criCfgTypeId;
		public string criSecondId;
		public string criItemType;
		public string criItemValue;
		public int criItemCount;
		public int criItemOdds;
		public CfgGoodsVO criCfgGoods;
		public CfgGeneralLevelVO criCfgGeneralLevel;
		public CfgEquipmentLevelVO criCfgEquipmentLevel;
		public CfgSoulVO criCfgSoul;        
	}
}