
namespace com.core.battle.bo
{

	using HalfRound = com.core.battle.round.HalfRound;
	
	public class BattleResultBo
	{
        //[JsonIgnore]
        public HalfRound halfRound;

		public ReplayBo replay;
		public int battleType;
		public string background;



	}

}