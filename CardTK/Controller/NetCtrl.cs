using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardTK.Net;
using com.common.socket.vo;
using UnityEngine;



namespace CardTK.Controller
{
    public class NetCtrl : MonoBehaviour
    {
        private string _serverAddr;
        private int _serverPort;
        public static SocketClient SocketClient;

        void LoadCfg()
        {
            _serverAddr = "10.0.0.104";
            _serverPort = 11025;
        }

        void Awake()
        {
            LoadCfg();

            SocketClient = new SocketClient(_serverAddr, _serverPort)
            {
                Sysinfo = s => Debug.Log(s),
                OnAMFMsgReceived = d =>
               {
                   Debug.Log("Message Received...");
                   var src = d.GetData();
                   if (src != null)
                   {
                       var reqv = src as ReqResVO;
                       if (reqv != null)
                       {
                           //Console.WriteLine("ReqResVO action:{0}, command:{1}",reqv.action,reqv.command);
                           Debug.Log("ReqResVO action:" + reqv.action + ", command:" + reqv.command);
                           var rdv = reqv.data as ResultDataVO;


                           var needCallback = true;
                           if (rdv != null)
                           {
                               // Debug.Log(1);
                               var nv = rdv.data as NotifyVO;
                               if (nv != null)
                               {
                                   Debug.Log("S1 NotifyVO eventName: " + nv.eventName);
                                   needCallback = false;
                                   if (Test.NotifyEvents.ContainsKey(nv.eventName)) Test.NotifyEvents[nv.eventName](nv.data);

                               }
                               //Debug.Log(2);
                               var nlv = rdv.data as NotifyListVO;
                               if (nlv != null)
                               {
                                   Debug.Log("NotifyListVO..");
                                   needCallback = false;
                                   //if (Test.NotifyEvents.ContainsKey(nv.eventName)) Test.NotifyEvents[nv.eventName](nv.data);
                               }


                               

                           }

                           var key = reqv.action + "#" + reqv.command;

                           if (Test.CallBackEvents.ContainsKey(key) && needCallback)
                           {
                               Debug.Log("key:" + key);
                               Test.CallBackEvents[key](rdv.data);
                           }



                       }
                       else
                       {
                           var nv = src as NotifyVO;
                           if (nv != null)
                           {
                               Debug.Log("S2 NotifyVO eventName: " + nv.eventName);
                               if (Test.NotifyEvents.ContainsKey(nv.eventName)) Test.NotifyEvents[nv.eventName](nv.data);

                           }
                       }
                   }
               }
            };

            SocketClient.Connect();

            SocketClient.Start();
        }

       

        //    SocketClient.Connect();

        //    SocketClient.Start();



        //}




        void OnDestroy()
        {
            //停止接收线程
            SocketClient.StopRev = true;
        }

    }

}
