using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgUnionSkillVO
	{
        public long cusId;
		public long cusUnionBuildLevel;
		public string cusName;
		public string cusPic;
		public string cusDesc;
		public int cusEffectiveTime;
		public string cuslType;
		public int cuslAddOne;
		public double cuslAddTwo;
		public CfgGoodsVO cusStudyGoods;
		public int cusStudyGoodsNum;
		public int cusStudySelfDevote;
		/// 
	}
}