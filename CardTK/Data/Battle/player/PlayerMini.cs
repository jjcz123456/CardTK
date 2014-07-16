using System;

namespace com.core.battle.player
{

    /// <summary>
    /// 用于解决怪物ID和人物ID冲突
    /// </summary>
    [Serializable]
    public class PlayerMini
    {
        public long pId;
        public int pType;

        public bool equalsExtra(Player other)
        {
            return (this.pId == other.pId && this.pType == other.pType);
        }
        public bool equals(PlayerMini other)
        {
            return (this.pId == other.pId && this.pType == other.pType);
        }

    }

}