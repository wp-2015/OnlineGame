using System;

public enum ClientSendType{
	UNKNOWN,
	LOGIN,
	REGISTER
}

public class SocketConst{

	public static string ServerIp = "127.0.0.1";
	public static int ServerPort = 5000;

	public static int DataByteLenget = 1024;
}

