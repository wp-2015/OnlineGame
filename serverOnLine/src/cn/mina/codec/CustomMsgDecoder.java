package cn.mina.codec;

import java.util.logging.Logger;

import org.apache.mina.core.buffer.IoBuffer;
import org.apache.mina.core.session.IoSession;
import org.apache.mina.filter.codec.CumulativeProtocolDecoder;
import org.apache.mina.filter.codec.ProtocolDecoderOutput;

import cn.mina.distribute.MsgPackage;
import cn.mina.distribute.MsgType.ClientSendType;

public class CustomMsgDecoder extends CumulativeProtocolDecoder{

	public static Logger logger = Logger.getLogger(CustomMsgDecoder.class.toString());
	
	@Override
	protected boolean doDecode(IoSession session, IoBuffer ioBuffer, ProtocolDecoderOutput out) throws Exception {
		// TODO 自动生成的方法存根
		if (ioBuffer.remaining() < 4)// 这里很关键，网上很多代码都没有这句，是用来当拆包时候剩余长度小于4的时候的保护，不加就出错咯
		{
			logger.info("数据包长度不足");
			return false;
		}
		if (ioBuffer.remaining() > 1) {
			ioBuffer.mark();// 标记当前位置，以便reset
			
			int length = ioBuffer.getInt();
			
			if (length > ioBuffer.remaining()) {// 如果消息内容不够，则重置，相当于不读取size
				logger.info("package notenough  left=" + ioBuffer.remaining() + " length=" + length);
				ioBuffer.reset();
				return false;// 接收新数据，以拼凑成完整数据
			} else {
				logger.info("package =" + ioBuffer.toString());
				
				int type = ioBuffer.getInt();
				
				byte[] bytes = new byte[length - 4];
				ioBuffer.get(bytes, 0, length - 4);
				
				out.write(new MsgPackage(ClientSendType.values()[type], bytes));
				
				return true;// 这里有两种情况1：没数据了，那么就结束当前调用，有数据就再次调用
			}
		}
		return false;// 处理成功，让父类进行接收下个包
	} 
}
