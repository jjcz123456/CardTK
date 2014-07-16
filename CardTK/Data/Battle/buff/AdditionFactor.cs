using System;

namespace com.core.battle.buff
{
	
	[Serializable]
	public class AdditionFactor
	{
        public AdditionDigit digit;
		public AdditionDigit factor;
		
		// ����
		public bool toCorpsCrit;
		public bool toTacticsCrit;
		public bool toVirtualCorpsCrit;
		public bool toVirtualWoodTacticsCrit;
		public bool toVirtualWaterTacticsCrit;
		public bool toVirtualFireTacticsCrit;
		
		//TODO �¼���2��Ԫ��  ��ֵ������
		public bool toVirtualLightTacticsCrit;
		public bool toVirtualDarkTacticsCrit;
		
		// ����
		public bool immuneCorpsCrit;		//����Ԫ�ؿ��Ʊ���
		public bool immuneTacticsCrit;
		public bool immuneTactics;
		public int immuneTacticsLtCritN;//ֻ�����߱���С��N���˺�
		public bool immuneCorps;
		public bool immuneCorpsShieldSuck;
		public bool immuneTacticsShieldSuck;
		// be
		public bool msNotEndRound;
		public bool msForbidden;
		public bool skip;

	}

}