using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgStarVO
	{
        public long csId;
		public string csName;
		public string csImage;
		public CfgAsterismVO csAsterismVO;
		public int csType;
		public int csFireTp;
		public int csWaterTp;
		public int csWoodTp;
		public int csFireMax;
		public int csWaterMax;
		public int csWoodMax;
		public CfgMajorSkillVO csMajorSkillVO;
		public long csNextId;
		public int csCost;
		public int csHead;        
	}
}