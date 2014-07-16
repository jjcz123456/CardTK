using System;

namespace com.core.battle.round
{

	using PlayerMini = com.core.battle.player.PlayerMini;

	[Serializable]
	public class SkillOpt
	{
        public PlayerMini soOr;
		public long skillId;
		public int skillType;
		public int skillElementType;
		public string skillName;
		public string soOppoImg;
		public string soSelfImg;

	}

}