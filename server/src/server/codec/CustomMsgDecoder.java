package server.codec;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.util.logging.Logger;

import org.apache.mina.core.buffer.IoBuffer;
import org.apache.mina.core.session.IoSession;
import org.apache.mina.filter.codec.CumulativeProtocolDecoder;
import org.apache.mina.filter.codec.ProtocolDecoderOutput;

import com.proto.Custom;

import server.ServerMain;

public class CustomMsgDecoder extends CumulativeProtocolDecoder{

	public static Logger logger = Logger.getLogger(CustomMsgDecoder.class.toString());
	
	private ByteArrayOutputStream byteArrayOutputStream;
	@Override
	protected boolean doDecode(IoSession session, IoBuffer ioBuffer, ProtocolDecoderOutput out) throws Exception {
		// 如果没有接收完Size部分（4字节），直接返回false
				if (ioBuffer.remaining() < 4)
					return false;
				else {
					// 标记开始位置，如果一条消息没传输完成则返回到这个位置
					ioBuffer.mark();
					
					byte[] bytes = new byte[4];
					ioBuffer.get(bytes);
					ByteArrayInputStream buf = new ByteArrayInputStream(bytes);

					DataInputStream dis= new DataInputStream (buf);
					
					
					
					byteArrayOutputStream = new ByteArrayOutputStream();

//					// 读取Size
//					byte[] bytes = new byte[4];
//					ioBuffer.get(bytes); // 读取4字节的Size
//					
//					for(int i = 0; i < 4; i++){
//						logger.info("" + bytes[i]);
//					}
//					
//					byteArrayOutputStream.write(bytes);
//					int bodyLength = Tools.DataTypeTranslater.bytesToInt(bytes, 0) - Tools.DataTypeTranslater.INT_SIZE; // 按小字节序转int
					
					logger.info("" + dis.readInt());

					// 如果body没有接收完整，直接返回false
//					if (ioBuffer.remaining() < bodyLength) {
//						ioBuffer.reset(); // IoBuffer position回到原来标记的地方
//						return false;
//					} else {
//						byte[] bodyBytes = new byte[bodyLength];
//						ioBuffer.get(bodyBytes);
////						String body = new String(bodyBytes, "UTF-8");
//						byteArrayOutputStream.write(bodyBytes);
//						
//						// 创建对象
////						NetworkPacket packetFromClient = new NetworkPacket(ioSession, byteArrayOutputStream.toByteArray());
////						
////						out.write(packetFromClient); // 解析出一条消息
//						return true;
//					}
					return false;
				}
	}

}
