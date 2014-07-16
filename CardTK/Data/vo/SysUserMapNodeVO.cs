using System.Collections.Generic;

namespace com.pokertk.data.vo
{


	public class SysUserMapNodeVO
	{
        public long sumnId;
		public long sumnUserId;
		public long sumnMapId;
		public CfgMapNodeVO sumnMapNodeVO;
		public int sumnIsPass;
		public bool sumnIsOpen;
		public int sumnNoPassCount;			//通过这个关卡的人数
		public List<object[]> sumnFirst5userId;	//前5名玩家id
        
	}
}