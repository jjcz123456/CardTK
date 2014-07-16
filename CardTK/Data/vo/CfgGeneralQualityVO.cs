using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgGeneralQualityVO
	{
        public int cgqId;				//主键
		public int cgqQuality;			//武将品质: 1-普通 2-优质 3-精良 4-稀有 5-传奇
		public double cgqGrowFactor;		//成长系数
		public int cgqNextRate;		//提升到下一级品质的成功率
		public int cgqNextId;		//下一级品质id
		public int cgqSilver;		//升到下一级需要的银币
		public CfgGoodsVO cfgGoodsVO;		//升到下一级需要的道具
		public int cgqGoodsNum;	//所需的道具数量
		/// 
	}

}