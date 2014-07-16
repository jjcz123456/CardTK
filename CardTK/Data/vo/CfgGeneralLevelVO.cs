using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgGeneralLevelVO
	{
        public long cglId;
		public CfgGeneralVO cglGeneralVO;
		public long cglNextId;
		public int cglExp;
		public int cglEqualExp;
        public int cglLevel;
	}
}