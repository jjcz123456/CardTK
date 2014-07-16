using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{   
    public class StreamReadBuffer
	{
		public static const int PROTOCOL_TYPE_SIZE = 4;
		public static const int HEADER_SIZE = 4;
		
		//协议类型
		private byte[]  _pTypeBuffer;
		//标记长度的buffer
		private byte[] _pLenBuffer;
		//数据buffer
		private byte[] _pDataBuffer;
		
		private int _pos = 0;
		
		public StreamReadBuffer()
		{
			_pTypeBuffer = new byte[1024];
			_pLenBuffer = new byte[1024];
			_pDataBuffer = new byte[1024];
		}
		

        public int Remain
        {
            get
            {
                if(_pos < PROTOCOL_TYPE_SIZE + HEADER_SIZE) 
                    return PROTOCOL_TYPE_SIZE + HEADER_SIZE - _pos;
                else
	{
                    _pLenBuffer.position = 0;
			return PROTOCOL_TYPE_SIZE + HEADER_SIZE + _pLenBuffer.readInt() - _pos;
	}


            }
        }

		public int remain() {
			if(_pos < PROTOCOL_TYPE_SIZE + HEADER_SIZE) return PROTOCOL_TYPE_SIZE + HEADER_SIZE - _pos;
			_pLenBuffer.position = 0;
			return PROTOCOL_TYPE_SIZE + HEADER_SIZE + _pLenBuffer.readInt() - _pos;
		}
		
		public function readFrom(data: IDataInput): void {
			var len: int = 0;
			if(_pos < PROTOCOL_TYPE_SIZE) {
				len = Math.min(PROTOCOL_TYPE_SIZE - _pos, data.bytesAvailable);
				if(len > 0) {
					data.readBytes(_pTypeBuffer,_pos, len);
					_pos += len;
					//trace("[---]read size:" + len);
				}
			}
			
			if(_pos >= PROTOCOL_TYPE_SIZE && _pos < PROTOCOL_TYPE_SIZE + HEADER_SIZE) {
				len = Math.min(PROTOCOL_TYPE_SIZE + HEADER_SIZE - _pos, data.bytesAvailable);
				if(len > 0) {
					data.readBytes(_pLenBuffer, _pLenBuffer.length, len);
					_pos += len;
				}
			}
			
			if(_pos >= PROTOCOL_TYPE_SIZE + HEADER_SIZE) {
				_pLenBuffer.position = 0;
				var dataBufferLen: int = _pLenBuffer.readInt();
				//Logger.debug(Amf3Protocol,"head len:" + dataBufferLen);
				len = Math.min(dataBufferLen + PROTOCOL_TYPE_SIZE + HEADER_SIZE - _pos ,data.bytesAvailable);
				if(len > 0) {
					data.readBytes(_pDataBuffer,_pDataBuffer.length, len);
					_pos += len;
					//trace("[---]read size:" + len);
				}
			}
			if(remain() == 0) {
				_pDataBuffer.position = 0;
			}
			//Logger.debug(Amf3Protocol,"data len:" + _pDataBuffer.length);
		}
		
		public function getProtocolType(): int {
			_pTypeBuffer.position = 0;
			return _pTypeBuffer.readInt();
		}
		
		public function getData(): ByteArray {
			_pDataBuffer.position = 0;
			return _pDataBuffer;
		}
	}
}
