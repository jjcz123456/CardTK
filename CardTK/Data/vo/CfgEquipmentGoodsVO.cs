using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgEquipmentGoodsVO
	{
        public long ceqgStrongLevel;
		public CfgGoodsVO ceqgGoods;
		public int ceqgGoodsNum;
		public int ceqgSilverNum;
		public int ceqgOdds;
		public CfgGoodsVO ceqgAddOddsGoods;
        public int ceqgAddOddsGoodsOdds;
	}
}