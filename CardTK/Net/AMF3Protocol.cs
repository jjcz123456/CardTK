using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluorineFx.AMF3;

namespace CardTK.Net
{
    public class AMF3Protocol
    {
        private ByteArray _readBodyBytes = null;
        private Object writeObject = null;

        //是否须有zlib压缩, 只压缩body数据块
        private bool _compress = false;

        //public function Amf3Protocol()
        //{
        //}

        //public function GetProtocolType(): int {
        //    return ProtocolType.AMF3_PROTOCOL;
        //}

        // ==================== 通讯: 发送与接受 ====================

        public void SetBytes(ByteArray bytes)
        {
            _readBodyBytes = bytes;
        }

        public ByteArray GetBytes()
        {
            if (writeObject == null) throw new Exception("write object is null");
            var byteArray = new ByteArray();
            byteArray.WriteObject(writeObject);
            return byteArray;
        }

        // =========== 应用层: 数据读写 =============

        public void SetData(Object obj)
        {
            writeObject = obj;
        }

        public Object GetData()
        {
            _readBodyBytes.Position = 0;            
            return _readBodyBytes.ReadObject();
        }

        // =========== 压缩设置 ==============

        public void setCompress(bool value)
        {
            _compress = value;
        }
    }
}
