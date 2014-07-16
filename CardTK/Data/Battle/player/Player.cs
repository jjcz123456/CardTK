using com.core.battle.board;
using com.core.battle.buff;
using com.pokertk.data.vo;
using System;
using System.Collections.Generic;

namespace com.core.battle.player
{





    //using Poker = com.core.battle.board.Poker;
    //using AdditionFactor = com.core.battle.buff.AdditionFactor;
    //using Buff = com.core.battle.buff.Buff;
    //using Dot = com.core.battle.dot.Dot;
    //using AdditionCycle = com.core.battle.enums.AdditionCycle;
    //using BenefitType = com.core.battle.enums.BenefitType;
    //using GeneralSkillType = com.core.battle.enums.GeneralSkillType;
    //using PlayerType = com.core.battle.enums.PlayerType;
    //using PoElementType = com.core.battle.enums.PoElementType;
    //using NextRoundFactor = com.core.battle.round.NextRoundFactor;
    //using OppositeDetailMf = com.core.battle.round.OppositeDetailMf;
    //using SkillMini = com.core.battle.skill.SkillMini;
    //using SkillStatistics = com.core.battle.skill.SkillStatistics;
    //using CfgDataMgr = com.pokertk.cache.CfgDataMgr;
    //using CfgAiVO = com.pokertk.data.vo.CfgAiVO;
    //using CfgCorpsSkillLevelVO = com.pokertk.data.vo.CfgCorpsSkillLevelVO;
    //using CfgCorpsVO = com.pokertk.data.vo.CfgCorpsVO;
    //using CfgEquipmentVO = com.pokertk.data.vo.CfgEquipmentVO;
    //using CfgMajorSkillVO = com.pokertk.data.vo.CfgMajorSkillVO;
    //using CfgMonsterVO = com.pokertk.data.vo.CfgMonsterVO;
    //using CfgSuitLevelVO = com.pokertk.data.vo.CfgSuitLevelVO;
    //using CfgSuitVO = com.pokertk.data.vo.CfgSuitVO;
    //using SysUserBackpackVO = com.pokertk.data.vo.SysUserBackpackVO;
    //using SysUserCorpsSkillVO = com.pokertk.data.vo.SysUserCorpsSkillVO;
    //using SysUserEquipmentLevelVO = com.pokertk.data.vo.SysUserEquipmentLevelVO;
    //using SysUserGeneralVO = com.pokertk.data.vo.SysUserGeneralVO;
    //using SysUserSkillVO = com.pokertk.data.vo.SysUserSkillVO;
    //using SysUserSuitVO = com.pokertk.data.vo.SysUserSuitVO;
    //using SysUserVO = com.pokertk.data.vo.SysUserVO;
    //using SexType = com.pokertk.enums.SexType;

    /// <summary>
    /// 鈥滅帺瀹垛�?
    /// </summary>
    [Serializable]
    public class Player
    {
        public long pId;
        /// <summary>
        /// 1怪物，0玩家
        /// </summary>
        public int pType;
        public int pSex;
        public string pName;
        public string pImage;
        public string vImage;
        public int pLevel;
        public int pHpMax;



        public List<SysUserGeneralVO> generalList;
        public List<CfgMajorSkillVO> skillList;
        public List<CfgCorpsVO> corpsList;

        public AdditionFactor addition;
        public List<Poker> handPokers;
        public bool unexpected;
        public int roomId;

        public int pDefense;
        public int pFireAtk;
        public int pWaterAtk;
        public int pWoodAtk;
        public int pLightAtk;
        public int pDarkAtk;
        public int pFireTp;		//基本元素积累
        public int pWaterTp;
        public int pWoodTp;
        public int pFireMax;
        public int pWaterMax;
        public int pWoodMax;

        public int battlePower;// 战力

        /**
         * 卡牌攻击倍率
         */
        public double p2_0;
        public double p2_2;
        public double p3_0;
        public double p3_2;
        public double p4_0;
        public double p5_0;
        public double p0_0;

        /*
        * 当前元素数值
        */
        public int pFire;// 当前火元素值
        public int pWater;// 当前水元素值
        public int pWood;// 当前木元素值

        public int pHp;// 当前生命

        public bool equalsMini(PlayerMini other)
        {
            return (this.pId == other.pId && this.pType == other.pType);
        }
        public bool equals(Player other)
        {
            return (this.pId == other.pId && this.pType == other.pType);
        }

    }

}