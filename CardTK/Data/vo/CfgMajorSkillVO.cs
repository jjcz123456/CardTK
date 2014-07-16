using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgMajorSkillVO
	{
        public long cmsId;
		public string cmsName;
		public string cmsImage;
		public string cmsDesc;
		public int cmsFireCost;
		public int cmsWaterCost;
		public int cmsWoodCost;
		public double cmsFactor1;
		public int cmsElementType;
		public int cmsSkillDegree;
		public string cmsParam;
		public int cmsContinues;
		public int cmsEndRound;
		public int cmsState	;
		public int cmsSide	;
		public int cmsCalcType;
		public string cmsSelfImg;
		public string cmsOppoImg;
		/// 
	}
}