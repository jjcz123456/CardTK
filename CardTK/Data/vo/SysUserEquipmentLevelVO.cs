using System;

namespace com.pokertk.data.vo
{


	[Serializable]
	public class SysUserEquipmentLevelVO
	{
        public long sueId;
		public long susUserId;
		public CfgEquipmentLevelVO sueEquipmentLevel;
		public CfgSoulVO susSoul;
		public long sueEquipmentStrongLevel;
		public DateTime sueFirstWearTime;
		public int sueCanUseTime;
		public int sueIsOutTime;
		public DateTime serverTime;		
		public int sueAddHp;		
		public int sueAddDefense;		
		public int sueAddFireAtk;		
		public int sueAddWaterAtk;		
		public int sueAddWoodAtk;		
		public int sueAddLightAtk;		
		public int sueAddDarkAtk;		
		public int sueAddFireTp;		
		public int sueAddWaterTp;		
		public int sueAddWoodTp;		
		public int sueAddFireMax;		
		public int sueAddWaterMax;		
		public int sueAddWoodMax;		
		public int sueAddTimes;		
		public int sueExtraHp;		
		public int sueExtraDefense;		
		public int sueExtraFireAtk;		
		public int sueExtraWaterAtk;		
		public int sueExtraWoodAtk;		
		public int sueExtraLightAtk;		
		public int sueExtraDarkAtk;		
		public int sueExtraFireTp;		
		public int sueExtraWaterTp;		
		public int sueExtraWoodTp;		
		public int sueExtraFireMax;		
		public int sueExtraWaterMax;		
		public int sueExtraWoodMax;
		/// 
	}
}