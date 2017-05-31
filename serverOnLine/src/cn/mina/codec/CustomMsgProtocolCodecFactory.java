package cn.mina.codec;

import org.apache.mina.core.session.IoSession;
import org.apache.mina.filter.codec.ProtocolCodecFactory;
import org.apache.mina.filter.codec.ProtocolDecoder;
import org.apache.mina.filter.codec.ProtocolEncoder;

public class CustomMsgProtocolCodecFactory implements ProtocolCodecFactory{
	
	private final CustomMsgDecoder decoder;
	private final CustomMsgEncoder encoder;
	
	public CustomMsgProtocolCodecFactory() {
		// TODO 自动生成的构造函数存根
		decoder = new CustomMsgDecoder();
		encoder = new CustomMsgEncoder();
	}
	
	@Override
	public ProtocolDecoder getDecoder(IoSession arg0) throws Exception {
		// TODO 自动生成的方法存根
		return decoder;
	}

	@Override
	public ProtocolEncoder getEncoder(IoSession arg0) throws Exception {
		// TODO 自动生成的方法存根
		return encoder;
	}

	
}
