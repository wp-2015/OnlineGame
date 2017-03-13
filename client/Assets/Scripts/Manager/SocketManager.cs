using System.Net.Sockets;
using System.Collections.Generic;
using System;

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

	void OnAwake(){
		dataSendQueue = new Queue<SocketData>();
		dataReceiveQueue = new Queue<SocketData>();
	}

	void OnUpdate(){
		//send
		if(!bIsInSend){
			SendData();
		}

		//receive
		if(socket.Connected){
			ReceiveData();
		}
	}

	public void Connect(){
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Connect(SocketConst.ServerIp, SocketConst.ServerPort);
	}

	#region Send
	public void Send(byte[] data){
		dataSendQueue.Enqueue(new SocketData(SendIndex, data));
		SendIndex++;
	}

	/// <summary>
	/// Socket.Send方法是可靠的。但是Send的时候，是等到缓冲区发出的包被确认以后才继续发送后续的包。所以，即使网络的带宽很大，但是如果网络延迟高，发送速度也会很慢。
	/// Socket.BeginSend是把要发送的数据直接写入缓冲区，然后调用返回。BeginSend发送的时候，并不能确定发送是否成功。 
	/// BeginSend的时候，指定了一个回调方法，发送成功后，系统会调用这个回调方法。在回调方法中，可以通过EndSend来检查实际发送的字节数。
	/// </summary>
	private void SendData(){
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
}
