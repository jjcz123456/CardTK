using System;

namespace com.pokertk.data.bo
{

	/// <summary>
	/// 鑱婂ぉ娑堟伅 
	/// </summary>
	[Serializable]
	public class ChatMessageBO
	{
        /**
		* 发送者信息
		*/
		public long senderUserId;
		public string senderUserName;
		
		/**
		* 私聊时接受者信息
		*/
		public long receiverUserId;
		public string receiverUserName;
		
		/**
		* 玩家操作类型 
		* 	0-在文本输入框键入文字+表情
		* 	1-在背包中点击道具、装备展示
		*/
		public string operateType;
		
		/**
		* 频道
		* Constant. CHAT_CHANNEL_*
		*/
		public string channel;
		
		/**
		* 消息内容 
		*/
		public string messageContent;
		
		/**
		* 展示类型
		* 展示在聊天框中的文本
		* 展示背包ID(sys_user_backpack.id)
		*/
		public string showType;
		public string showText;
		public string showId;


	}

}