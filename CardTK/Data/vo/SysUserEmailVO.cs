using System;

namespace com.pokertk.data.vo
{

	public class SysUserEmailVO
	{
        public long suemId;
		public long suemUserId;
		public string suemEmailType;
		public string suemEmailTheme;
		public string suemEmailContent;
		public DateTime suemEmailTime;
		public int suemEmailIsRead;
		public int suemEmailIsGet;
	}
}