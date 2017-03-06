package server;

import java.util.logging.Logger;

import org.apache.mina.core.service.IoHandlerAdapter;
import org.apache.mina.core.session.IdleStatus;
import org.apache.mina.core.session.IoSession;

public class ServerSocketHandler extends IoHandlerAdapter {
	public static Logger logger = Logger.getLogger(ServerSocketHandler.class.toString());
	
	@Override
	public void sessionCreated(IoSession session) throws Exception {
		logger.info("客户端连接 : " + session.getId());
	}

	@Override
	public void sessionOpened(IoSession session) throws Exception {
		logger.info("客户端打开 ： " + session.getId());
//		session.write("54323adsf");
	}

	@Override
	public void messageReceived(IoSession session, Object message)
			throws Exception {
		logger.info("服务端收到信息 session : " + session + "	message : " + message);
		if (message.equals("bye")) {
			session.close(true);
		}
	}

	@Override
	public void messageSent(IoSession session, Object message) throws Exception {
		logger.info("发送信息到客户端 , session : " + session.getId() + " message : " + message);
	}

	@Override
	public void sessionClosed(IoSession session) throws Exception {
		logger.info("客户端断开 : " + session.getId());
	}

	@Override
	public void sessionIdle(IoSession session, IdleStatus status)
			throws Exception {
//		logger.info("客户端空闲 ，session : " + session.getId() + " state : " + status.toString());
	}

	@Override
	public void exceptionCaught(IoSession session, Throwable cause)
			throws Exception {
		logger.info("服务端发送异常， session : " + session.getId() + " cause : " + cause.getMessage());
	}
}
