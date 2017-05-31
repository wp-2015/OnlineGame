package cn.mina.distribute;

public class MsgPackage {

	public byte[] byteMsg;
	public MsgType.ClientSendType type;
	
	public MsgPackage(MsgType.ClientSendType type, byte[] msg){
		this.type = type;
		this.byteMsg = msg;
	}
}
