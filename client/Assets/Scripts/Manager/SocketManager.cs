using System.Net.Sockets;
using System.Collections.Generic;
using System;
using System.IO;
using ProtoBuf;
using UnityEngine;

public class SocketData{
	public int Id{get;set;}
	public byte[] Data{get;set;}
	public SocketData(int id, byte[] data){
		this.Id = id;
		this.Data = data;
	}
}

public class SocketManager : Singleton<SocketManager>{

	private Socket socket;

	private Queue<SocketData> dataSendQueue;
	private bool bIsInSend = false;//是否在发送过程中

	private Queue<SocketData> dataReceiveQueue;
	private byte[] dataReceiveTemp = new byte[SocketConst.DataByteLenget];
	private bool bIsInReceive = false;

	private int SendIndex = 0;

	void Awake(){
		Connect();
		dataSendQueue = new Queue<SocketData>();
		dataReceiveQueue = new Queue<SocketData>();
	}

	void Update(){
		//receive
		if(socket.Connected){
			ReceiveData();
		}
	}

	private bool Connect(){
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Connect(SocketConst.ServerIp, SocketConst.ServerPort);
		if(socket.Connected){
			Debug.Log("Connect to server success");
			return true;
		}else{
			Debug.LogError("Connect to server failed");
		}
		return false;
	}

	#region Send
//	public void Send(byte[] data){
//		dataSendQueue.Enqueue(new SocketData(SendIndex, data));
//		SendIndex++;
//	}

	public void SendData<T>(ClientSendType type, T t){
		if(!socket.Connected){
			Debug.LogError("is not connected");
			return;
		}
		byte[] msg;
		using (MemoryStream ms = new MemoryStream()){
			Serializer.Serialize<T>(ms, t);
			msg = new byte[ms.Length];
			ms.Position = 0;
			ms.Read(msg, 0, msg.Length);
		}

		byte[] data = new byte[8 + msg.Length];

		byte[] len = IntToBytes(msg.Length + 4);//长度
		Buffer.BlockCopy(len, 0, data, 0, 4);

		byte[] bType = IntToBytes((int)type);//类型
		Buffer.BlockCopy(bType, 0, data, 4, 4);

		Buffer.BlockCopy(msg, 0, data, 8,msg.Length);

		IAsyncResult asyncSend = socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendData), socket);    //开始发送
		bool success = asyncSend.AsyncWaitHandle.WaitOne(5000, true);
		if (!success)
		{
			Debug.Log("asyncSend error close socket");
		}else{
			Debug.Log("success");
		}
	}

	/// <summary>
	/// Socket.Send方法是可靠的。但是Send的时候，是等到缓冲区发出的包被确认以后才继续发送后续的包。所以，即使网络的带宽很大，但是如果网络延迟高，发送速度也会很慢。
	/// Socket.BeginSend是把要发送的数据直接写入缓冲区，然后调用返回。BeginSend发送的时候，并不能确定发送是否成功。 
	/// BeginSend的时候，指定了一个回调方法，发送成功后，系统会调用这个回调方法。在回调方法中，可以通过EndSend来检查实际发送的字节数。
	/// </summary>
	private void SendData(IAsyncResult iar){
		bIsInSend = true;
		SocketData data = dataSendQueue.Dequeue();
		socket.BeginSend(data.Data, 0, data.Data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);    //开始发送
	}

	private void SendCallback(IAsyncResult iar){
		bIsInSend = false;
	}
	#endregion

	#region receive
	public void ReceiveData(){
		if(!bIsInReceive){
			bIsInReceive = true;
			IAsyncResult res = socket.BeginReceive(dataReceiveTemp, 0, dataReceiveTemp.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
		}
	}

	private void ReceiveCallback(IAsyncResult iar){
		bIsInReceive = false;
		Socket remote = (Socket)iar.AsyncState;
		int recv = remote.EndReceive(iar);
		if (recv > 0){
			
		}
	}
	#endregion

	public void Close(){
		if(null != socket){
			try{
				lock(this){
					socket.Shutdown(SocketShutdown.Both);
					socket.Close();
					socket = null;
					dataSendQueue.Clear();
					dataReceiveQueue.Clear();
				}
			}catch(Exception ex){
				Debugger.Log("Socket close : " + ex);
				socket = null;
			}
		}
	}

	public static byte[] IntToBytes(int num){
		byte[] bytes = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			bytes[i] = (byte)(num >> (24 - i * 8));
		}
		return bytes;
	}
}
