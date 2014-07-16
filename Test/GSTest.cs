using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using System.Threading;

using Newtonsoft.Json;

namespace Test
{
    internal class GSTest
    {
        public TcpClient TClient;

        public GSTest() 
        {
            TClient = new TcpClient();
        }


        public void Connect() 
        {
            TClient.Connect("115.29.188.9", 3721);
            if (TClient.Connected)
            {
                Console.WriteLine("Connect Success");

                //var RevThread = new Thread(new ThreadStart(Receive));
                //RevThread.Start();
            }
        }

       

        public void Send(object obj) 
        {
            if (!TClient.Connected)
            {
                Console.WriteLine("Connection Erro");
                return;
            }


            var jstr = JsonConvert.SerializeObject(obj);
            var data = Encoding.UTF8.GetBytes(jstr);
            var head = BitConverter.GetBytes(data.Length);


            var bytes = head.Concat(data).ToArray();

            Console.WriteLine("Sending msg: {0}, ", jstr);
            TClient.Client.Send(bytes);
        }

        private void Receive() 
        {

        }

    }



    public class User 
    {
        public UInt64 ID;
        public string Name;
    }
}
