package cn.mina.msghandle;

import cn.helper.UserHelper;
import cn.mina.msg.ClientSend;

public class Login {
	
	public void LoginByMsg(byte[] byteMsg) throws Exception{
		ClientSend.User user = ClientSend.User.parseFrom(byteMsg);
		UserHelper helper = new UserHelper();
		helper.findUserByAccount(user.getAccount());
	}
	
	
}
