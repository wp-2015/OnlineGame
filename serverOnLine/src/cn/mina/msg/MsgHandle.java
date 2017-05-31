package cn.mina.msg;

import cn.mina.distribute.MsgPackage;
import cn.mina.msghandle.Register;

public class MsgHandle {

	public void Handle(MsgPackage msg) throws Exception{
		System.out.println(msg.type);
		switch (msg.type) {
		case LOGIN:
			
			break;
		case REGISTER:
			new Register().RegisterByMsg(msg.byteMsg);
			break;

		default:
			break;
		}
	}
}
