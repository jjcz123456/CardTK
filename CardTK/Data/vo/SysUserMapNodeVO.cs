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
		public int sumnNoPassCount;			//ͨ������ؿ�������
		public List<object[]> sumnFirst5userId;	//ǰ5�����id
        
	}
}