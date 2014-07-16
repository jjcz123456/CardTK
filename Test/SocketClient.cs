using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using FluorineFx;

namespace Test
{
    class SocketClient
    {

        //private const string CommandName = "CobolCommandMobile";
        //private const string TerminateString = "<EOF>";
        private const int ReceiveBufferSize = 1024;

        private readonly string _remoteServer;
        private readonly int _remotePort;
        private readonly TcpClient _tcpClient;
        private StringBuilder _sb = new StringBuilder();

        //public event MessageReceived NewMessageReceived;
        //public event ConnectionClosed OnConnectionClosed;
        public Action<string> NewMessageReceived;
        //public Action<Exception> OnConnectionClosed;
        //public Action<string> OnTest;

        public SocketClient(string remoteServer, int remotePort)
        {
            _remoteServer = remoteServer;
            _remotePort = remotePort;
            _tcpClient = new TcpClient();
        }

        public void Connect()
        {
            if (_tcpClient.Connected)
                throw new Exception("Connected, cannot re-connect.");

            //_tcpClient.SendTimeout = 1000000;
           // _tcpClient.ReceiveTimeout = 1000000;
            _tcpClient.Connect(_remoteServer, _remotePort);
            if (_tcpClient.Connected) { }

            

                //GameManager.ErrorMsg.Enqueue(new Exception("Socket Connected"));
                //Console.WriteLine("connected");
            //ThreadPool.QueueUserWorkItem(ReceiveMessage, _tcpClient.Client);
            //Thread.Sleep(2000);//强制暂停，为了上面的线程运行

            Thread rev = new Thread(new ThreadStart(ReceiveMessage));
            rev.Start();

        }

        public void Close()
        {
            if (!_tcpClient.Connected)
                throw new Exception("Closed, cannot re-close.");

            _tcpClient.Close();
        }

        
        public void ReceiveMessage()
        {
            //var socket = (System.Net.Sockets.Socket)state;
            while(_tcpClient.Connected)
            {
                try
                {
                    var buffer = new byte[ReceiveBufferSize];
                    var receivedSize = _tcpClient.Client.Receive(buffer);
                    var rawMsg = Encoding.UTF8.GetString(buffer, 0, receivedSize);
                    
                    //var rnFixLength = TerminateString.Length;
                    for (var i = 0; i < rawMsg.Length; )
                    {
                        if (i <= rawMsg.Length - rnFixLength)
                        {
                            if (rawMsg.Substring(i, rnFixLength) != TerminateString)
                            {
                                _sb.Append(rawMsg[i]);
                                i++;
                            }
                            else
                            {
                                OnNewMessageReceived(_sb.ToString());
                                _sb = new StringBuilder();
                                i += rnFixLength;
                            }
                        }
                        else
                        {
                            _sb.Append(rawMsg[i]);
                            i++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //GameManager.ErrorMsg.Enqueue(ex);
                    _tcpClient.Close();
                }
            }
            _tcpClient.Close();
        }

        private void OnNewMessageReceived(string msg)
        {
            var bytes = Convert.FromBase64String(msg);
            var b = GZipCompress.DeCompress(bytes);
            var stringBytes = Encoding.UTF8.GetString(b);
            if (NewMessageReceived != null)
                NewMessageReceived(stringBytes);
        }

        public void Send(string str)
        {
            if(!_tcpClient.Connected)
                throw new Exception("Closed, cannot send data.");

           
            var byteArray = Encoding.UTF8.GetBytes(str + "\r\n");
            _tcpClient.Client.Send(byteArray);
        }

        //private string GetResult(params object[] args)
        //{
        //    var json = JsonConvert.SerializeObject(args);
        //    var stringByte = GZipCompress.Compress(json);
        //    return stringByte;
        //}

        //public void Send(params object[] args)
        //{
        //    var headerByte = GetResult(null);
        //    var bodyByte = GetResult(args);
        //    Send(CommandName + " " + headerByte + " " + bodyByte);
        //}

    }
}






