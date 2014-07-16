using System;
using System.Collections.Generic;

namespace com.pokertk.data.vo
{


	//using AdditionFactor = com.core.battle.buff.AdditionFactor;

	
	public class SysUserVO
	{
        public long suId;
		public SysAccountVO suAccountVO;
		public string suName;
		public string suUnionName;
		public int suLevel;
		public int suVipLevel;
		public int suSex;
		public int suGold;
		public int suSilver;
		public int suSoul;
		public int suPrestige;
		public int suExp;
		public int suExpUp;
		public int suSp;
		public int suHpMax;
		public CfgTitleVO suTitleVO;
		public int suDefense;
		public int suFireAtk;
		public int suWaterAtk;
		public int suWoodAtk;
		public int suLightAtk;
		public int suDarkAtk;
		public int suFireTp;
		public int suWaterTp;
		public int suWoodTp;
		public int suFireMax;
		public int suWaterMax;
		public int suWoodMax;
		public int suBattlePower;
		public int suWinNumber;
		public int suInviteNumber;		
		public SysUserSuitVO curSuit;
		public List<SysUserBackpackVO> equipmentList;
		public List<SysUserStarVO> starList;
		public List<SysUserGeneralVO> generalList;
		public List<SysUserSkillVO>  skillList;
		public bool offline;
		public string suHeadphoto;
		public bool hasGuide;
		public SysUserGuideVO userGuide;
		public List<SysUserBuffVO> buffList;
		public DateTime suLoginTime;
		public DateTime suLoginOutTime;		
		public SysUserSettingVO setting;		
		public CfgUnionBuildGuardianVO unionGuardian;
		public bool isGuardianActive;
		public int suGameScoreTop;		
		public int suTotalRecharge;



        //private const long serialVersionUID = 6515378390660329500L;

        //private long? suId;
        //private string openId;
        //private SysAccountVO suAccountVO;
        //private string suName;
        //private string suUnionName;
        //private int? suLevel;
        //private int? suVipLevel;
        //private int? suSex;
        //private int? suGold;
        //private int? suSilver;
        //private int? suSoul;
        //private int? suPrestige;
        //private int? suExp;
        //private int? suExpUp;
        //private int? suSp;
        //private int? suHpMax;
        //private CfgTitleVO suTitleVO; //当前官职

        //private int? suDefense;
        //private int? suFireAtk;
        //private int? suWaterAtk;
        //private int? suWoodAtk;
        //private int? suLightAtk;
        //private int? suDarkAtk;
        //private int? suFireTp;
        //private int? suWaterTp;
        //private int? suWoodTp;

        //private int? suFireMax; //元素槽上�?
        //private int? suWaterMax;
        //private int? suWoodMax;

        //private int? suStrategy; //谋略�?

        //private int? suIsMatch; //是否竞技大厅匹配�?-�?0-否（未匹配这第一次默认使用机器人�?

        //private DateTime suLoginTime;
        //private DateTime suLoginOutTime;

        ////临时属�?
        //private AdditionFactor addition; //装备等加�?

        //private int? suBattlePower; //战力
        //private int? suWinNumber; //胜利场次
        //private int? suInviteNumber;

        //private int? suTotalRecharge; //总的充值金�?

        //private SysUserSuitVO curSuit; //穿着的套�?
        //private IList<SysUserBackpackVO> equipmentList; //穿戴的装�?
        //private IList<SysUserStarVO> starList; //激活的将星

        //private IList<SysUserGeneralVO> generalList; //出战的武�?
        //private IList<SysUserSkillVO> skillList; //出战的主技�?

        //private bool offline; //是否离线
        //private string suHeadphoto;

        //private bool hasGuide; // 是否存在未完成的新手引导
        //private SysUserGuideVO userGuide; // 玩家当前新手引导

        //private IList<SysUserBuffVO> buffList; //用户当前的buff状�?

        //private IList<SysUserCorpsSkillVO> corpsSkillList; //用户特殊卡牌技能列�?

        //private IList<SysUserUnionSkillVO> unionSkillList; //用户公会技能列�?

        //private CfgUnionBuildGuardianVO unionGuardian; //神兽祝福
        //private bool isGuardianActive;

        //private SysUserSettingVO setting; //玩家配置

        //private int suGameScoreTop; //小游戏最高分

        //public virtual SysUserSettingVO getSetting()
        //{
        //    return setting;
        //}

        //public virtual void setSetting(SysUserSettingVO setting)
        //{
        //    this.setting = setting;
        //}

        //public virtual string SuHeadphoto
        //{
        //    get
        //    {
        //        return suHeadphoto;
        //    }
        //    set
        //    {
        //        this.suHeadphoto = value;
        //    }
        //}


        //public virtual bool Offline
        //{
        //    get
        //    {
        //        return offline;
        //    }
        //    set
        //    {
        //        this.offline = value;
        //    }
        //}


        //public SysUserVO()
        //{
        //}

        //public SysUserVO(long suId)
        //{
        //    this.suId = suId;
        //}

        //public virtual IList<SysUserStarVO> StarList
        //{
        //    get
        //    {
        //        return starList;
        //    }
        //    set
        //    {
        //        this.starList = value;
        //    }
        //}


        //public virtual CfgTitleVO getSuTitleVO()
        //{
        //    return suTitleVO;
        //}

        //public virtual long? SuId
        //{
        //    get
        //    {
        //        return suId;
        //    }
        //    set
        //    {
        //        this.suId = value;
        //    }
        //}


        //public virtual SysAccountVO getSuAccountVO()
        //{
        //    return suAccountVO;
        //}

        //public virtual void setSuAccountVO(SysAccountVO suAccountVO)
        //{
        //    this.suAccountVO = suAccountVO;
        //}

        //public virtual string SuName
        //{
        //    get
        //    {
        //        return suName;
        //    }
        //    set
        //    {
        //        this.suName = value;
        //    }
        //}


        //public virtual int? SuLevel
        //{
        //    get
        //    {
        //        return suLevel;
        //    }
        //    set
        //    {
        //        this.suLevel = value;
        //    }
        //}


        //public virtual int? SuVipLevel
        //{
        //    get
        //    {
        //        return suVipLevel;
        //    }
        //    set
        //    {
        //        this.suVipLevel = value;
        //    }
        //}


        //public virtual int? SuSex
        //{
        //    get
        //    {
        //        return suSex;
        //    }
        //    set
        //    {
        //        this.suSex = value;
        //    }
        //}


        //public virtual int? SuGold
        //{
        //    get
        //    {
        //        return suGold;
        //    }
        //    set
        //    {
        //        this.suGold = value;
        //    }
        //}


        //public virtual int? SuSilver
        //{
        //    get
        //    {
        //        return suSilver;
        //    }
        //    set
        //    {
        //        this.suSilver = value;
        //    }
        //}


        //public virtual int? SuExp
        //{
        //    get
        //    {
        //        return suExp;
        //    }
        //    set
        //    {
        //        this.suExp = value;
        //    }
        //}


        //public virtual int? SuExpUp
        //{
        //    get
        //    {
        //        return suExpUp;
        //    }
        //    set
        //    {
        //        this.suExpUp = value;
        //    }
        //}


        //public virtual int? SuSp
        //{
        //    get
        //    {
        //        return suSp;
        //    }
        //    set
        //    {
        //        this.suSp = value;
        //    }
        //}


        //public virtual int? SuHpMax
        //{
        //    get
        //    {
        //        return suHpMax;
        //    }
        //    set
        //    {
        //        this.suHpMax = value;
        //    }
        //}



        //public virtual int? SuFireMax
        //{
        //    get
        //    {
        //        return suFireMax;
        //    }
        //    set
        //    {
        //        this.suFireMax = value;
        //    }
        //}


        //public virtual int? SuWaterMax
        //{
        //    get
        //    {
        //        return suWaterMax;
        //    }
        //    set
        //    {
        //        this.suWaterMax = value;
        //    }
        //}


        //public virtual int? SuBattlePower
        //{
        //    get
        //    {
        //        return suBattlePower;
        //    }
        //    set
        //    {
        //        this.suBattlePower = value;
        //    }
        //}


        //public virtual IList<SysUserGeneralVO> GeneralList
        //{
        //    get
        //    {
        //        return generalList;
        //    }
        //    set
        //    {
        //        this.generalList = value;
        //    }
        //}


        //public virtual IList<SysUserSkillVO> SkillList
        //{
        //    get
        //    {
        //        return skillList;
        //    }
        //    set
        //    {
        //        this.skillList = value;
        //    }
        //}


        //public virtual SysUserSuitVO getCurSuit()
        //{
        //    return curSuit;
        //}

        //public virtual void setCurSuit(SysUserSuitVO curSuit)
        //{
        //    this.curSuit = curSuit;
        //}

        //public virtual int? SuSoul
        //{
        //    get
        //    {
        //        return suSoul;
        //    }
        //    set
        //    {
        //        this.suSoul = value;
        //    }
        //}


        //public virtual int? SuPrestige
        //{
        //    get
        //    {
        //        return suPrestige;
        //    }
        //    set
        //    {
        //        this.suPrestige = value;
        //    }
        //}


        //public virtual IList<SysUserBackpackVO> EquipmentList
        //{
        //    get
        //    {
        //        return equipmentList;
        //    }
        //    set
        //    {
        //        this.equipmentList = value;
        //    }
        //}


        //public virtual AdditionFactor Addition
        //{
        //    get
        //    {
        //        return addition;
        //    }
        //    set
        //    {
        //        this.addition = value;
        //    }
        //}


        //public virtual SysUserGuideVO getUserGuide()
        //{
        //    return userGuide;
        //}

        //public virtual void setUserGuide(SysUserGuideVO userGuide)
        //{
        //    this.userGuide = userGuide;
        //}

        //public virtual bool HasGuide
        //{
        //    get
        //    {
        //        return hasGuide;
        //    }
        //    set
        //    {
        //        this.hasGuide = value;
        //    }
        //}


        //public virtual IList<SysUserBuffVO> BuffList
        //{
        //    get
        //    {
        //        return buffList;
        //    }
        //    set
        //    {
        //        this.buffList = value;
        //    }
        //}


        //public virtual int? SuDefense
        //{
        //    get
        //    {
        //        return suDefense;
        //    }
        //    set
        //    {
        //        this.suDefense = value;
        //    }
        //}


        //public virtual int? SuFireAtk
        //{
        //    get
        //    {
        //        return suFireAtk;
        //    }
        //    set
        //    {
        //        this.suFireAtk = value;
        //    }
        //}


        //public virtual int? SuWaterAtk
        //{
        //    get
        //    {
        //        return suWaterAtk;
        //    }
        //    set
        //    {
        //        this.suWaterAtk = value;
        //    }
        //}


        //public virtual int? SuWoodAtk
        //{
        //    get
        //    {
        //        return suWoodAtk;
        //    }
        //    set
        //    {
        //        this.suWoodAtk = value;
        //    }
        //}


        //public virtual int? SuLightAtk
        //{
        //    get
        //    {
        //        return suLightAtk;
        //    }
        //    set
        //    {
        //        this.suLightAtk = value;
        //    }
        //}


        //public virtual int? SuDarkAtk
        //{
        //    get
        //    {
        //        return suDarkAtk;
        //    }
        //    set
        //    {
        //        this.suDarkAtk = value;
        //    }
        //}


        //public virtual int? SuFireTp
        //{
        //    get
        //    {
        //        return suFireTp;
        //    }
        //    set
        //    {
        //        this.suFireTp = value;
        //    }
        //}


        //public virtual int? SuWaterTp
        //{
        //    get
        //    {
        //        return suWaterTp;
        //    }
        //    set
        //    {
        //        this.suWaterTp = value;
        //    }
        //}


        //public virtual int? SuWoodTp
        //{
        //    get
        //    {
        //        return suWoodTp;
        //    }
        //    set
        //    {
        //        this.suWoodTp = value;
        //    }
        //}


        //public virtual int? SuWoodMax
        //{
        //    get
        //    {
        //        return suWoodMax;
        //    }
        //    set
        //    {
        //        this.suWoodMax = value;
        //    }
        //}


        //public virtual void setSuTitleVO(CfgTitleVO suTitleVO)
        //{
        //    this.suTitleVO = suTitleVO;
        //}

        //public virtual int? SuIsMatch
        //{
        //    get
        //    {
        //        return suIsMatch;
        //    }
        //    set
        //    {
        //        this.suIsMatch = value;
        //    }
        //}


        //public virtual IList<SysUserCorpsSkillVO> CorpsSkillList
        //{
        //    get
        //    {
        //        return corpsSkillList;
        //    }
        //    set
        //    {
        //        this.corpsSkillList = value;
        //    }
        //}


        //public virtual int? SuStrategy
        //{
        //    get
        //    {
        //        return suStrategy;
        //    }
        //    set
        //    {
        //        this.suStrategy = value;
        //    }
        //}


        //public virtual DateTime SuLoginTime
        //{
        //    get
        //    {
        //        return suLoginTime;
        //    }
        //    set
        //    {
        //        this.suLoginTime = value;
        //    }
        //}


        //public virtual DateTime SuLoginOutTime
        //{
        //    get
        //    {
        //        return suLoginOutTime;
        //    }
        //    set
        //    {
        //        this.suLoginOutTime = value;
        //    }
        //}


        //public virtual IList<SysUserUnionSkillVO> UnionSkillList
        //{
        //    get
        //    {
        //        return unionSkillList;
        //    }
        //    set
        //    {
        //        this.unionSkillList = value;
        //    }
        //}


        //public virtual CfgUnionBuildGuardianVO getUnionGuardian()
        //{
        //    return unionGuardian;
        //}

        //public virtual void setUnionGuardian(CfgUnionBuildGuardianVO unionGuardian)
        //{
        //    this.unionGuardian = unionGuardian;
        //}

        //public virtual string SuUnionName
        //{
        //    get
        //    {
        //        return suUnionName;
        //    }
        //    set
        //    {
        //        this.suUnionName = value;
        //    }
        //}


        //public virtual string OpenId
        //{
        //    get
        //    {
        //        return openId;
        //    }
        //    set
        //    {
        //        this.openId = value;
        //    }
        //}


        //public virtual int? SuInviteNumber
        //{
        //    get
        //    {
        //        return suInviteNumber;
        //    }
        //    set
        //    {
        //        this.suInviteNumber = value;
        //    }
        //}


        //public virtual int? SuWinNumber
        //{
        //    get
        //    {
        //        return suWinNumber;
        //    }
        //    set
        //    {
        //        this.suWinNumber = value;
        //    }
        //}


        //public virtual bool IsGuardianActive
        //{
        //    get
        //    {
        //        return isGuardianActive;
        //    }
        //    set
        //    {
        //        this.isGuardianActive = value;
        //    }
        //}


        //public virtual int SuGameScoreTop
        //{
        //    get
        //    {
        //        return suGameScoreTop;
        //    }
        //    set
        //    {
        //        this.suGameScoreTop = value;
        //    }
        //}


        //public virtual int? SuTotalRecharge
        //{
        //    get
        //    {
        //        return suTotalRecharge;
        //    }
        //    set
        //    {
        //        this.suTotalRecharge = value;
        //    }
        //}




	}

}