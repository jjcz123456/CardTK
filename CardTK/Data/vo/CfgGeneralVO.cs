using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgGeneralVO
	{
        public long cgId;
		public int cgElementId;
		public string cgName;
		public string cgImage;
		public string cgDesc;
		public CfgGeneralSkillVO cgGeneralSkillVO;
		public int  cgNameType;		
		public int cgType;		
		public int cgInitAtk;		
		public int cgInitHp;		
		public double cgGrowAtk;		
		public double cgGrowHp;
		/// 
	}
}