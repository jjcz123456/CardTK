using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgTitleVO
	{
        public long ctId;
		public string ctName;
		public string ctDesc;
		public int ctDefense;
		public int ctPrestige;
		public long ctNextId;
		public CfgGiftVO titleGiftVO;
	}
}