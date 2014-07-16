using System;
using System.Collections.Generic;

namespace com.core.battle.round
{


	using CfgCorpsVO = com.pokertk.data.vo.CfgCorpsVO;
    
	
	[Serializable]
	public class Pokerline
	{

        public int from;
		public int to;
		public long corpsComboType;
		public List<int> restrainPos;
		public List<CfgCorpsVO> corpsLevelList;
		/// 

	}

}