using com.core.battle.board;
using com.core.battle.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardTK.Components
{
    public class PlayerMono : MonoBehaviour
    {
        private Player _player;

        public Player Player
        {
            get { return _player; }
            set 
            {
                _player = value;
                //Debug.Log(HandPokers.Count);


                for (int i = 0; i < value.handPokers.Count; i++)
                {
                    //Debug.Log("Pos: " + value.handPokers[i].pos);
                    HandPokers[value.handPokers[i].pos - 1].Poker = value.handPokers[i];
                }

                
            }
        }

        public PokerMono FirstP;
        public PokerMono SecondP;


        public UILabel NameLabel;
        public UILabel HPLable;


        public List<PokerMono> HandPokers;

        
    }
}
