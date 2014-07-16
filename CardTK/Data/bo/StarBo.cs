using System.Collections.Generic;

namespace com.pokertk.data.bo
{


	using CfgAsterismVO = com.pokertk.data.vo.CfgAsterismVO;
	using SysUserStarVO = com.pokertk.data.vo.SysUserStarVO;

	public class StarBo
	{
        public CfgAsterismVO caVO;
		public bool enabled;
		public List<SysUserStarVO> starList;


	}

}