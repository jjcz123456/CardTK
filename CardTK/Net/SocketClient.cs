using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using com.common.socket.vo;
using FluorineFx.AMF3;
using FluorineFx.Util;

//using Newtonsoft.Json;
//using System.Text;

namespace CardTK.Net
{
    public class SocketClient
    {
        private readonly string _remoteServer;
        private readonly int _remotePort;

        private readonly TcpClient _tcpClient;

        private const int PROTOCOL_TYPE_SIZE = 4;
        private const int HEADER_SIZE = 4;

        //协议类型
        //private List<byte> _pTypeBuffer;
        private byte[] _pTypeBuffer;
        //标记长度的buffer
        //private List<byte> _pLenBuffer;
        private byte[] _pLenBuffer;
        //数据buffer
        //private List<byte> _pDataBuffer;
        private byte[] _pDataBuffer;
        private int _pos;

        private int _dataLength;

        //private Thread RevThread;

        public bool StopRev;
        //private DateTime _testTime;


        private string _testMsg;

        private int Remain
        {
            get
            {
                return _pos < PROTOCOL_TYPE_SIZE + HEADER_SIZE ? PROTOCOL_TYPE_SIZE + HEADER_SIZE - _pos :
                    PROTOCOL_TYPE_SIZE + HEADER_SIZE + _dataLength - _pos;
            }
        }

        public Action<AMF3Protocol> OnAMFMsgReceived;

        //public Action<string> OnDataReceived;

        public Action<string> Sysinfo;

        //public Action<string> OnInitMsgReceived;





        public SocketClient(string remoteServer, int remotePort)
        {
            _remoteServer = remoteServer;
            _remotePort = remotePort;
            _tcpClient = new TcpClient();



            Reset();
        }

        public void Connect()
        {
            if (_tcpClient.Connected)
            {
                if (Sysinfo != null)
                    Sysinfo("Connected, cannot re-connect.");
                return;
            }
            //throw new Exception("Connected, cannot re-connect.");

            //_tcpClient.SendTimeout = 1000000;
            // _tcpClient.ReceiveTimeout = 1000000;
            _tcpClient.Connect(_remoteServer, _remotePort);
            if (_tcpClient.Connected)
            {
                if (Sysinfo != null)
                    Sysinfo("Connect Succeed!");
            }



        }

        public void Close()
        {
            if (!_tcpClient.Connected)
            {
                if (Sysinfo != null)
                    Sysinfo("Closed, cannot re-close.");
                return;
            }
            _tcpClient.Close();
        }

        public void Start()
        {
            if (!_tcpClient.Connected)
            {
                if (Sysinfo != null)
                    Sysinfo("Socket Closed, Cannot send data.");
                return;
            }

            var msg = new ByteArray();

            msg.WriteUTFBytes("1");
            var m = msg.GetBuffer();
            _tcpClient.Client.Send(m);

            //var m = Encoding.UTF8.GetBytes("1");
            //_tcpClient.Client.Send(m);

            StopRev = false;


            Sysinfo("Start Listen...");
            //var RevThread = new Thread(new ThreadStart(ReceiveMessage));
            var RevThread = new Thread(new ThreadStart(Receive));
            RevThread.Start();


        }


        public void Send(string act, string cmd, Object data)
        {
            if (!_tcpClient.Connected)
                throw new Exception("Closed, cannot send data.");
            
            
            var reqResVO = new ReqResVO();

            reqResVO.accountId = SessionInfo._currentSysUserVO == null ?
                0 : SessionInfo._currentSysUserVO.suAccountVO.saId;
            reqResVO.userId = SessionInfo._currentSysUserVO == null ?
                0 : SessionInfo._currentSysUserVO.suId;

            reqResVO.sessionId = 0;
            reqResVO.action = act;
            reqResVO.command = cmd;
            reqResVO.data = data;

            //var id: String = getIdByVO(reqResVO);

            //if(callback != null) _callbackMap[id] = callback;

            //Logger.debug(SocketService,reqResVO.toString());

            //var protocol: IProtocol = ProtocolBuilder.newProtocol(ProtocolType.AMF3_PROTOCOL);
            
            
            var protocol = new AMF3Protocol();

            protocol.SetData(reqResVO);

            var b1 = protocol.GetBytes();

            var b2 = FluorineFx.Util.Convert.ToByteArray(b1);

            var msg = new ByteArray();

            msg.WriteInt(1);
            msg.WriteInt((int)b1.Length);

            var b3 = b2.Take((int)b1.Length).ToArray();

            msg.WriteBytes(b3, 0, b3.Length);

            b3 = FluorineFx.Util.Convert.ToByteArray(msg).Take((int)msg.Length).ToArray();


            Sysinfo("Sending " + act + "#" + cmd);
            
            _tcpClient.Client.Send(b3);


        }



        //public void Send(string act, string cmd, Object data)
        //{



        //    if (!_tcpClient.Connected)
        //        throw new Exception("Closed, cannot send data.");

        //    var reqResVO = new ReqResVO();

        //    reqResVO.accountId = SessionInfo._currentSysUserVO == null ?
        //        0 : SessionInfo._currentSysUserVO.suAccountVO.saId;
        //    reqResVO.userId = SessionInfo._currentSysUserVO == null ?
        //        0 : SessionInfo._currentSysUserVO.suId;

        //    reqResVO.sessionId = 0;
        //    reqResVO.action = act;
        //    reqResVO.command = cmd;
        //    reqResVO.data = data;


        //    int proType = 2;
        //    var b1 = BitConverter.GetBytes(proType).Reverse().ToArray();

        //    var js = JsonConvert.SerializeObject(reqResVO);
        //    Sysinfo("sending: " + js);
        //    var b3 = Encoding.UTF8.GetBytes(js);


        //    //var data = Encoding.UTF8.GetBytes(msg);
        //    int datalen = b3.Length;

        //    var b2 = BitConverter.GetBytes(datalen).Reverse().ToArray();


        //    //JsonConvert.SerializeObject(reqResVO)

        //    var bb = b1.Concat(b2).Concat(b3).ToArray();
        //    //for (int i = 0; i < b3.Length; i++)
        //    //{
        //    //    Console.WriteLine(b3[i]);
        //    //}

        //    _tcpClient.Client.Send(bb);
        //}

        //private void ReceiveMessage()
        //{
        //    try
        //    {
        //        //while (_readBuffer.Remain() > 0 && _tcpClient.Client.Available > 2)
        //        while (_tcpClient.Connected && !StopRev)
        //        {
        //            if (_tcpClient.Client.Available == 0) continue;
        //            //Console.WriteLine("msg received, size : " + _tcpClient.Available);
        //            var raw = new byte[_tcpClient.Available];
        //            _tcpClient.Client.Receive(raw);
        //            //var rawlist = raw.ToList();
        //            while (raw.Length > 0)
        //            {
        //                ReadFrom(raw);
        //            }
        //        }
        //        return;

        //    }
        //    catch (Exception ex)
        //    {
        //        if (Sysinfo != null) Sysinfo(ex.Message);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        _tcpClient.Close();
        //    }
        //}

        private void Receive()
        {
            try
            {
                //while (_readBuffer.Remain() > 0 && _tcpClient.Client.Available > 2)
                while (_tcpClient.Connected && !StopRev)
                {
                    if (_tcpClient.Client.Available == 0) continue;
                    //Console.WriteLine("msg received, size : " + _tcpClient.Available);
                    var raw = new byte[_tcpClient.Available];
                    _tcpClient.Client.Receive(raw);
                    //var rawlist = raw.ToList();

                    ReadFrom(raw);

                }
                return;

            }
            catch (Exception ex)
            {
                if (Sysinfo != null)
                {
                    Sysinfo(ex.Message);
                    //Sysinfo(ex.Source);
                    //Sysinfo()
                    Sysinfo(_testMsg);
                }
                throw ex;
            }
            finally
            {
                _tcpClient.Close();
            }
        }



        private void ReadFrom(byte[] src)
        {
            var len = 0;

            if (_pos < PROTOCOL_TYPE_SIZE)
            {
                len = Math.Min(PROTOCOL_TYPE_SIZE - _pos, src.Length);

                if (len > 0)
                {
                    _pTypeBuffer = _pTypeBuffer.Concat(src.Take(len)).ToArray();
                    src = src.Skip(len).ToArray();


                    if (_pTypeBuffer.Length == PROTOCOL_TYPE_SIZE)
                    {
                        _pTypeBuffer = _pTypeBuffer.Reverse().ToArray();

                        var c = BitConverter.ToInt32(_pTypeBuffer, 0);
                    }


                    _pos += len;
                }

            }

            if (_pos >= PROTOCOL_TYPE_SIZE && _pos < PROTOCOL_TYPE_SIZE + HEADER_SIZE)
            {
                len = Math.Min(PROTOCOL_TYPE_SIZE + HEADER_SIZE - _pos, src.Length);
                if (len > 0)
                {
                    _pLenBuffer = _pLenBuffer.Concat(src.Take(len)).ToArray();
                    src = src.Skip(len).ToArray();


                    if (_pLenBuffer.Length == HEADER_SIZE)
                    {
                        _pLenBuffer = _pLenBuffer.Reverse().ToArray();

                        _dataLength = BitConverter.ToInt32(_pLenBuffer, 0);
                    }

                    _pos += len;
                }
            }

            if (_pos >= PROTOCOL_TYPE_SIZE + HEADER_SIZE)
            {
                len = Math.Min(_dataLength + PROTOCOL_TYPE_SIZE + HEADER_SIZE - _pos, src.Length);
                if (len > 0)
                {
                    _pDataBuffer = _pDataBuffer.Concat(src.Take(len)).ToArray();
                    src = src.Skip(len).ToArray();

                    _pos += len;
                }
            }
            if (Remain == 0)
            {                
                //var rawStr = Encoding.UTF8.GetString(_pDataBuffer, 0, _pDataBuffer.Length);

                //_testMsg = rawStr;
                //if (OnDataReceived != null)
                //{
                //    OnDataReceived(rawStr);
                //}


                //Sysinfo("Message Received.");

                var a3p = new AMF3Protocol();
                //a3p.SetBytes
                var da = new ByteArray();
                da.WriteBytes(_pDataBuffer, 0, _pDataBuffer.Length);
                a3p.SetBytes(da);

                if (OnAMFMsgReceived != null)
                {
                    OnAMFMsgReceived(a3p);
                }

                Reset();

            }

            if (src.Length > 0)
            {
                ReadFrom(src);
            }

        }

        private void Reset()
        {
            _pTypeBuffer = new byte[] { };
            _pLenBuffer = new byte[] { };
            _pDataBuffer = new byte[] { };
            _pos = _dataLength = 0;
        }

    }
}
