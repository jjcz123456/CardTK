using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgEquipmentLevelVO
	{
        public long ceqlId;
		public CfgEquipmentVO ceqlEquipment;
		public CfgEquipmentGoodsVO ceqlEquipmentGoods;
		public long ceqlNextLevelId;
		public long ceqlStrongLevel;
		public int ceqlSellPrice;
		public int ceqlBaseHp;
		public int ceqlBaseDefense;
		public int ceqlBaseFireAtk;
		public int ceqlBaseWaterAtk;
		public int ceqlBaseWoodAtk;
		public int ceqlBaseLightAtk;
		public int ceqlBaseDarkAtk;
		public int ceqlBaseFireTp;
		public int ceqlBaseWaterTp;
		public int ceqlBaseWoodTp;
		public int ceqlBaseFireMax;
		public int ceqlBaseWaterMax;
		public int ceqlBaseWoodMax;
		public int ceqlAddHp;
		public int ceqlAddDefense;
		public int ceqlAddFireAtk;
		public int ceqlAddWaterAtk;
		public int ceqlAddWoodAtk;
		public int ceqlAddLightAtk;
		public int ceqlAddDarkAtk;
		public int ceqlAddFireTp;
		public int ceqlAddWaterTp;
		public int ceqlAddWoodTp;
		public int ceqlAddFireMax;
		public int ceqlAddWaterMax;
		public int ceqlAddWoodMax;		
		public int ceqlAddLimit;
		public int ceqlAddInitNum;

	}
}