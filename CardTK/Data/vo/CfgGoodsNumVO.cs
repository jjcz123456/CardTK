using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgGoodsNumVO
	{
        public long cgnId;
		public int cgnGoodsType;
		public CfgGoodsVO cgnGoods;
		public int cgnGoodsNum;
		public int cgnGoodsDailyNum;
		public int cgnSilverNum;
	}
}