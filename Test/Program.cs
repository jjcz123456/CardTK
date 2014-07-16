using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CardTK.Net;
using System.Threading;
using com.common.socket.vo;
using CardTK.Confs;
using System.Net.Sockets;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Test
{

    class Program
    {



        static void Main(string[] args)
        {

            //byte[] a = new byte[] { 0, 0, 0, 0 };
            //int a = 1;
            // var b = BitConverter.GetBytes(a);

            Console.WriteLine("What?");

            var r = Console.ReadKey();
            if (r.Key == ConsoleKey.D1)
            {
                //Test2();
            }
            else
            {
                Test3();
            }




            Console.ReadKey();

        }

        //static void Test1() 
        //{
        //    SocketClient _sc = new SocketClient("10.0.0.104", 11025);
        //    _sc.Sysinfo = s => Console.WriteLine(s);


        //    _sc.OnAMFMsgReceived = d => 
        //    {
        //        //Console.WriteLine("Message Received"); 

        //        var src = d.GetData();
        //        if (src != null) 
        //        {
        //            var reqv = src as ReqResVO;                    
        //            if (reqv != null)
        //            {
        //                Console.WriteLine("ReqResVO action:{0}, command:{1}",reqv.action,reqv.command);
        //                var rdv = reqv.data as ResultDataVO;
        //                if (rdv != null)
        //                {                            
        //                    var nv = rdv.data as NotifyVO;
        //                    if (nv != null)
        //                    {

        //                        //Console.WriteLine(nv.eventName); 

        //                    }
        //                    else
        //                    {
        //                        var nlv = rdv.data as NotifyListVO;
        //                        if (nlv != null)
        //                        {
        //                            //Console.WriteLine(nlv.);
        //                        }
        //                    }                           

        //                }
        //            }
        //            else
        //            {
        //                var nv = src as NotifyVO;
        //                if (nv != null)
        //                {
        //                    Console.WriteLine(nv.eventName);
        //                }
        //            }
        //        }
        //    };

        //    _sc.Connect();

        //    //Dictionary<string, string> msg = new Dictionary<string, string>();
        //    //msg.Add("accountName", "super1");
        //    //msg.Add("accountPassword", "");


        //    _sc.Start();
        //}

        //static void Test2()
        //{
        //    SocketClient _sc = new SocketClient("10.0.0.104", 11025);
        //    _sc.Sysinfo = s => Console.WriteLine(s);

        //    _sc.OnDataReceived = d =>
        //    {

        //        Console.WriteLine("Message Received...");

        //        JObject Jo = JObject.Parse(d);

        //        //var rawo = JsonConvert.DeserializeObject(d);

        //        //var js = JsonSerializer.Create();
        //        //js.MissingMemberHandling = MissingMemberHandling.Ignore;
        //        //js.TypeNameHandling = TypeNameHandling.All;

        //        //Console.WriteLine(Jo.);

        //        var nv = Jo.ToObject<NotifyVO>();


        //        if (nv.eventName != null)
        //        {
        //            Console.WriteLine("NotifyVO eventName::{0}", nv.eventName);
        //        }
        //        else
        //        {
        //            var reqv = Jo.ToObject<ReqResVO>();

        //            Console.WriteLine("ReqResVO action:{0}, command:{1}", reqv.action, reqv.command);



        //            var rdv = JObject.FromObject(reqv.data).ToObject<ResultDataVO>();
        //            var needCallback = true;

        //            var nfv = JObject.FromObject(rdv.data).ToObject<NotifyVO>();
        //            if (nfv.eventName != null)
        //            {
        //                Console.WriteLine("NotifyVO eventName::{0}", nfv.eventName);
        //                needCallback = false;
        //                //if (Test.NotifyEvents.ContainsKey(nv.eventName)) Test.NotifyEvents[nv.eventName](nv.data);

        //            }
        //            //var jlo = JObject.FromObject()
        //            var nlv = JObject.FromObject(rdv.data).ToObject<NotifyListVO>();

        //            if (nlv.notifyVOList != null)
        //            {
        //                Console.WriteLine("NotifyListVO");
        //                needCallback = false;
        //                //if (Test.NotifyEvents.ContainsKey(nv.eventName)) Test.NotifyEvents[nv.eventName](nv.data);
        //            }









        //            //var key = reqv.action + "#" + reqv.command;

        //            //if (Test.CallBackEvents.ContainsKey(key) && needCallback)
        //            //{
        //            //    Debug.Log("key:" + key);
        //            //    //Test.CallBackEvents[key](rdv.data);
        //            //}

        //        }

        //    };


        //    _sc.Connect();
        //    _sc.Start();



        //    Hashtable ht = new Hashtable()
        //    {
        //        {Conf.ACCOUNT_NAME, "super1"},
        //        {Conf.ACCOUNT_PASSWORD, ""}
        //    };

        //    //NetCtrl.SocketClient.Send(Conf.USER_FACADE, Conf.LOGIN_ACCOUNT, ht);

        //    _sc.Send(Conf.USER_FACADE, Conf.LOGIN_ACCOUNT, ht);

        //}


        static void Test3()
        {
            GSTest gst = new GSTest();

            gst.Connect();

            User a = new User() { ID = 123, Name = "王老吉" };
            User b = new User() { ID = 222, Name = "周润发" };

            gst.Send(new List<User>() { a, b });

        }


    }
}
