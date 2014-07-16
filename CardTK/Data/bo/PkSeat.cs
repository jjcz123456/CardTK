using System;

namespace com.pokertk.data.bo
{

	using SysUserVO = com.pokertk.data.vo.SysUserVO;

	
	[Serializable]
	public class PkSeat
	{
        public int psId;
		public SysUserVO user;
		public bool ready;
	}

}