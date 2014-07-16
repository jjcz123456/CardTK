using System;

namespace com.pokertk.data.vo
{
	[Serializable]
	public class SysUserUnionSkillVO
	{
        public int suusId;
		public int suusUnionId;
		public int suusUserId;
		public CfgUnionSkillVO cfgUnionSkill;
		public DateTime suusStudyTime;
		public int suusEffectiveTime;
		public int suusIsOvertime;

	}
}