using com.core.battle.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardTK.Components
{
    public class PokerMono : MonoBehaviour
    {

        public Vector3 OriPos;
        public Transform OriParent;

        private Poker _poker;
        public Poker Poker 
        {
            get { return _poker; }
            set
            {
                _poker = value;
                if (value != null)
                {
                    Label.text = value.valid ? value.elementType.ToString() : "空";
                }
                else
                {
                    Label.text = "";
                }
                
            }
        }


       

        public UILabel Label;

        public int InTablePos;

        public void Reset()
        {
            transform.parent = OriParent;
            transform.localPosition = OriPos;
            collider2D.enabled = true;
        }

    }
}
