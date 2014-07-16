using System;

namespace com.core.battle.round
{
    using CardTK.Controller;
    using PlayerMini = com.core.battle.player.PlayerMini;

	[Serializable]
	public class Opt
	{

        public PlayerMini optOr;
		public OptType optType;
		public int elapsedTime;
		public LineOpt lineOpt;
		public SkillOpt skillOpt;
		public long optToken;
		/// 

	}

}