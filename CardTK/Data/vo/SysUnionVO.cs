using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class SysUnionVO
	{
        public long suniId;
		public string suniName;
		public SysUserUnionVO sysUserUnion;
		public string suniLeaderName;
		public int suniWealth;
		public int suniRank;
		public int suniMemberNum;
		public CfgUnionVO cfgUnion;
		public CfgUnionBuildSmithVO cfgUnionBuildSmith;
		public CfgUnionBuildSkillVO cfgUnionBuildSkill;
		public CfgUnionBuildGuardianVO cfgUnionBuildGuardian;
		public CfgUnionBuildMarketVO cfgUnionBuildMarket;
		public string suniDeclare;
		public int suniWeekDebtTimes;
		public int suniGuardianHungry;
		public int suniGuardianState;
		public string suniJob1;
		public string suniJob2;
		public string suniJob3;
		public string suniJob4;
		public string suniJob5;
		public string suniJob6;
	}
}