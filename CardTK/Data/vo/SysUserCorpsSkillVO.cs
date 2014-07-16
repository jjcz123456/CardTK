using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class SysUserCorpsSkillVO
	{
        public long sucsId;
		public long sucsUserId;
		public CfgCorpsSkillLevelVO sucsLevelVO;
		public int sucsStoreValue;
        public int sucsIsActive;

	}
}