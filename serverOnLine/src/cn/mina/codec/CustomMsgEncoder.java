package cn.mina.codec;

import java.nio.charset.Charset;
import org.apache.mina.core.buffer.IoBuffer;
import org.apache.mina.core.session.IoSession;
import org.apache.mina.filter.codec.ProtocolEncoderAdapter;
import org.apache.mina.filter.codec.ProtocolEncoderOutput;

public class CustomMsgEncoder extends ProtocolEncoderAdapter{

	@Override
	public void encode(IoSession session, Object message, ProtocolEncoderOutput output) throws Exception {
		// TODO 自动生成的方法存根
//		IoBuffer buf = IoBuffer.allocate(100).setAutoExpand(true);
//		String strOut = message.toString();// DateSecret.encryptDES(message.toString());//别看这里的处理，这里是我的数据包加密算法~你可以直接拿message.toString当数据
//		buf.putInt(strOut.getBytes(Charset.forName("utf-8")).length);
//		buf.putString(strOut, Charset.forName("utf-8").newEncoder());
//		buf.flip();
//		output.write(buf);
		
		IoBuffer buf = IoBuffer.allocate(100).setAutoExpand(true);
		String strOut = message.toString();// DateSecret.encryptDES(message.toString());//别看这里的处理，这里是我的数据包加密算法~你可以直接拿message.toString当数据
		buf.putString(strOut, Charset.forName("utf-8").newEncoder());
		buf.flip();
		output.write(buf);
	}

}
