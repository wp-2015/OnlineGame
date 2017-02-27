package server;

import org.apache.mina.core.service.IoAcceptor;
import org.apache.mina.core.session.IdleStatus;
import org.apache.mina.filter.codec.ProtocolCodecFilter;
import org.apache.mina.filter.codec.textline.LineDelimiter;
import org.apache.mina.filter.codec.textline.TextLineCodecFactory;
import org.apache.mina.transport.socket.nio.NioSocketAcceptor;

import java.net.InetSocketAddress;
import java.nio.charset.Charset;
import java.util.logging.Logger;;

public class ServerMain {

	public static Logger logger = Logger.getLogger(ServerMain.class.toString());
	private static int PORT = 5000;
	
	public static void main(String[] args) {
		// TODO 自动生成的方法存根
		IoAcceptor acceptor = null;
		try {
			acceptor = new NioSocketAcceptor();
			
			acceptor.getFilterChain().addLast("codec", new ProtocolCodecFilter(new TextLineCodecFactory(Charset.forName("UTF-8"), LineDelimiter.WINDOWS.getValue(), LineDelimiter.WINDOWS.getValue())));
			
			acceptor.getSessionConfig().setReadBufferSize(2048);
			
			acceptor.getSessionConfig().setIdleTime(IdleStatus.BOTH_IDLE, 10);
			
			acceptor.setHandler(new ServerSocketHandler());
			
			acceptor.bind(new InetSocketAddress(PORT));
			logger.info("服务端bind端口成功， 端口 ： " + PORT);
		} catch (Exception e) {
			// TODO: handle exception
			logger.info("服务端启动异常 ： " + e.getMessage());
			e.printStackTrace();
		}
	}

}
