using System;

namespace com.core.battle.buff
{
	
	[Serializable]
	public class AdditionFactor
	{
        public AdditionDigit digit;
		public AdditionDigit factor;
		
		// 暴击
		public bool toCorpsCrit;
		public bool toTacticsCrit;
		public bool toVirtualCorpsCrit;
		public bool toVirtualWoodTacticsCrit;
		public bool toVirtualWaterTacticsCrit;
		public bool toVirtualFireTacticsCrit;
		
		//TODO 新加入2中元素  数值待计算
		public bool toVirtualLightTacticsCrit;
		public bool toVirtualDarkTacticsCrit;
		
		// 免疫
		public bool immuneCorpsCrit;		//免疫元素卡牌暴击
		public bool immuneTacticsCrit;
		public bool immuneTactics;
		public int immuneTacticsLtCritN;//只能免疫倍率小于N的伤害
		public bool immuneCorps;
		public bool immuneCorpsShieldSuck;
		public bool immuneTacticsShieldSuck;
		// be
		public bool msNotEndRound;
		public bool msForbidden;
		public bool skip;

	}

}