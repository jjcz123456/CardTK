using System;
using System.Collections.Generic;

namespace com.pokertk.data.vo
{

    [Serializable]
    public class CfgMonsterVO
    {
        public long cmId;
        public int cmType;
        public string cmName;
        public int cmLevel;
        public string cmImage;
        public int cmHpMax;
        public int cmDefense;
        public int cmFireAtk;
        public int cmWaterAtk;
        public int cmWoodAtk;
        public int cmLightAtk;
        public int cmDarkAtk;
        public int cmFireMax;
        public int cmWaterMax;
        public int cmWoodMax;
        public int cmFireTp;
        public int cmWaterTp;
        public int cmWoodTp;
        public string cmGenerals;
        public string cmSkills;
        public List<SysUserGeneralVO> generalList;
        public List<CfgMajorSkillVO> skillList;
        public CfgAiVO cmAiVO;
    }
}