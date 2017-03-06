using System;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System.IO;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

using ProtoBuf;

public class Client : MonoBehaviour {

	public static int iDataLength = 1024;
	private byte[] readData = new byte[iDataLength];
	public string receiveString;

	private Socket socket;
	// Use this for initialization
	void Start () {
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Connect("127.0.0.1",5001);//101.200.171.91
	}
	bool bIsSend = false;
	void Update()
	{
		if(socket.Connected){
			startReceive();
		}

		if(!bIsSend && socket.Connected){
			bIsSend = true;
			Send("123");
		}
//		if(null != receiveString && !receiveString.Equals("")){
//			Debug.Log(receiveString);
//			receiveString = "";
//		}
	}
	bool ReceiveFlag = true;
	void startReceive()
	{
		if (ReceiveFlag) {
			ReceiveFlag = false;
			socket.BeginReceive(readData, 0, readData.Length, SocketFlags.None, new AsyncCallback(endReceive), socket);
		}           
	}

	void endReceive(IAsyncResult iar) //接收数据
	{
		ReceiveFlag = true;
		Socket remote = (Socket)iar.AsyncState;
		int recv = remote.EndReceive(iar);
		if (recv > 0)
		{
			receiveString = Encoding.UTF8.GetString(readData, 0, recv);
		}

	}

	public void Send(string str)
	{
		byte[] msg = serial();

		byte[] data = new byte[4 + msg.Length];
		byte[] len = int2bytes(msg.Length);//BitConverter.GetBytes(msg.Length);
		Debug.Log("len : " + len.Length);
		Buffer.BlockCopy(len, 0, data, 0, 4);
//		IntToBytes(msg.Length).CopyTo(data, 0);

		Debug.Log("length : " + msg.Length);

		Buffer.BlockCopy(msg, 0, data, 4,msg.Length);

		foreach(var i in msg){
			Debug.Log(i);
		}


		Debug.Log("head : " + BitConverter.ToInt32(data, 0));
		IAsyncResult asyncSend = socket.BeginSend(msg, 0, msg.Length, SocketFlags.None, new AsyncCallback(SendData), socket);    //开始发送
		bool success = asyncSend.AsyncWaitHandle.WaitOne(5000, true);
		if (!success)
		{
			Debug.Log("asyncSend error close socket");
		}else{
			Debug.Log("success");
		}
	}

	static byte[] int2bytes(int n)  
	{  
		byte[] targets = new byte[4];

		targets[0] = (byte) (n & 0xff);// 最低位 
		targets[1] = (byte) ((n >> 8) & 0xff);// 次低位 
		targets[2] = (byte) ((n >> 16) & 0xff);// 次高位 
		targets[3] = (byte) (n >> 24);// 最高位,无符号右移。 
		return targets;   
	}  

	void SendData(IAsyncResult iar) //发送数据
	{
		Socket remote = (Socket)iar.AsyncState;
		int sent = remote.EndSend(iar);         //关闭发送
		Debug.Log("send the mag`s length is : " + sent);
	}

	byte[] serial(){
		NetMsg.LRequest re = new NetMsg.LRequest();
		re.nEmployeeID = 10;
		re.strSerialNumber = "123";
		re.strUrl = "321";

		using (MemoryStream ms = new MemoryStream()){
			Serializer.Serialize<NetMsg.LRequest>(ms, re);
			byte[] data = new byte[ms.Length];
			ms.Position = 0;
			ms.Read(data, 0, data.Length);
			return data;
		}
	}

	public static byte[] IntToBytes(int num)
	{
		byte[] bytes = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			bytes[i] = (byte)(num >> (24 - i * 8));
		}
		return bytes;
	}

}
