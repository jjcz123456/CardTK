using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class CfgGeneralQualityVO
	{
        public int cgqId;				//����
		public int cgqQuality;			//�佫Ʒ��: 1-��ͨ 2-���� 3-���� 4-ϡ�� 5-����
		public double cgqGrowFactor;		//�ɳ�ϵ��
		public int cgqNextRate;		//��������һ��Ʒ�ʵĳɹ���
		public int cgqNextId;		//��һ��Ʒ��id
		public int cgqSilver;		//������һ����Ҫ������
		public CfgGoodsVO cfgGoodsVO;		//������һ����Ҫ�ĵ���
		public int cgqGoodsNum;	//����ĵ�������
		/// 
	}

}