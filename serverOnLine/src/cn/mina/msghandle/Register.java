package cn.mina.msghandle;

import cn.helper.UserHelper;
import cn.mina.msg.ClientSend;

public class Register {

	public void RegisterByMsg(byte[] byteMsg) throws Exception{
		ClientSend.User user = ClientSend.User.parseFrom(byteMsg);
		
		pojo.User u = new pojo.User();
//		u.setAccount(user.getAccount());
		u.setPassword(user.getPassword());
		u.setNickname(user.getNickname());
		
		UserHelper helper = new UserHelper();
		helper.insertUser(u);
	}
}
