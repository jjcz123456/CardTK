using System.Collections.Generic;

namespace com.pokertk.data.vo
{
    public class CfgMapNodeVO
    {
        public long cmnId;
        public CfgMapVO cmnCfgMap;
        public long cmnPreid;
        public string cmnPos;
        public string cmnNodeType;
        public string cmnIsLast;
        public CfgMonsterVO cmnCfgMonster;
        public string cmnImg;
        public List<CfgRewardItemVO> rewardItemList;
    }
}