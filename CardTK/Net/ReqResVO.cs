using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.common.socket.vo
{
    public class ReqResVO
    {
        public static int count = 0;
		
		public int id;
		
		public string ip;
		
		public long accountId;
		public long userId;
		public int sessionId;
		
		public string action;
		public string command;
		
		public Object data;
		
		public ReqResVO() {
			id = count ++;
			count = count % int.MaxValue;
		}
		
		public string toString() {
            return action + "#" + command + "#" + id;
		}
    }
}
