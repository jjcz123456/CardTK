using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class SysUserWarNodeVO
	{
        public long suwnId;
		public long suwnUserId;
		public long suwnWarId;
		public CfgWarNodeVO suwnCfgWarNode;
		public int suwnIsPass;
		public int suwnIsInTrap;
		public long suwnRandomId;

		/// 
		
	}
}