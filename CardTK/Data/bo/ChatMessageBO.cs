using System;

namespace com.pokertk.data.bo
{

	/// <summary>
	/// 聊天消息 
	/// </summary>
	[Serializable]
	public class ChatMessageBO
	{
        /**
		* ��������Ϣ
		*/
		public long senderUserId;
		public string senderUserName;
		
		/**
		* ˽��ʱ��������Ϣ
		*/
		public long receiverUserId;
		public string receiverUserName;
		
		/**
		* ��Ҳ������� 
		* 	0-���ı�������������+����
		* 	1-�ڱ����е�����ߡ�װ��չʾ
		*/
		public string operateType;
		
		/**
		* Ƶ��
		* Constant. CHAT_CHANNEL_*
		*/
		public string channel;
		
		/**
		* ��Ϣ���� 
		*/
		public string messageContent;
		
		/**
		* չʾ����
		* չʾ��������е��ı�
		* չʾ����ID(sys_user_backpack.id)
		*/
		public string showType;
		public string showText;
		public string showId;


	}

}