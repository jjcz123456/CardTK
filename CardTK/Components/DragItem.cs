using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardTK.Components
{
    public class DragItem : MonoBehaviour
    {
        public UIRoot UT;

        public PokerMono PM;

        public Action<GameObject> OnDropOnTable;

        public Action OnDragStart;

        //void OnTriggerEnter2D(Collider2D c2d) 
        //{
        //    Debug.Log(c2d.gameObject.name);
        //}

        void OnDrag(Vector2 delta)
        {
            transform.localPosition += (Vector3)delta * UT.pixelSizeAdjustment;
        }


        void OnPress(bool state)
        {
            if (!state)
            {
                //Debug.Log(UICamera.hoveredObject.GetComponent<UILabel>().text);
                //Debug.Log("haha");
                if (UICamera.hoveredObject != null)
                {
                    if (UICamera.hoveredObject.GetComponent<PokerMono>()!=null)
                    {
                        if (OnDropOnTable!=null)
                        {
                            OnDropOnTable(UICamera.hoveredObject);
                        }
                    }
                    else
                    {
                        PM.Reset();
                    }
                }
                else
                {
                    PM.Reset();
                }                

            }
            else
            {
                if (OnDragStart!= null)
                {
                    OnDragStart();
                }
                collider2D.enabled = false;
            }
        }

        

    }
}
