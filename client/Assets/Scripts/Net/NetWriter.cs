using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System;

public enum ResponseContentType
{
	Stream = 0,
	Json
}

public class NetWriter {

	private static ulong s_userID = 0;
	private static string s_strSessionID = "";
	private static string s_strTime = "";
	private static ResponseContentType _respContentType = ResponseContentType.Stream;
	private static string s_strUrl = "";
	private static string s_strPostData = "";
	private static string s_strUserData = "";
	private static int s_Counter = 1;
	private static string s_md5Key = "";
	private static byte[] _bodyBuffer;
	private static byte[] _headBuffer;
	private static NetWriter s_instance;

	public static NetWriter Instance{
		get{
			if(null != s_instance){
				s_instance = new NetWriter();
			}
			return s_instance;
		}
	}

	public static bool IsGet{get;private set;}

	public static ResponseContentType ResponseContentType{
		get{return _respContentType;}
	}

	public static int MsgId{
		get{return s_Counter;}
	}

	public static ulong UserID{
		get{return s_userID;}
		set{
			if(null != value){
				s_userID = value;
			}
		}
	}

	public static string SessionID{
		get{return s_strSessionID;}
		set{
			if(null != value){
				s_strSessionID = value;
				resetData();
			}
		}
	}

	public static string Time{
		get{return s_strTime;}
		set{
			if(null != value){
				s_strTime = value;
				resetData();
			}
		}
	}

	public static void SetMd5Key(string value){
		s_md5Key = value;
	}

	public static void resetData(){
		_headBuffer = null;
		_bodyBuffer = null;
		s_strPostData = "";
		s_strUserData = string.Format("MsgId={0}&Sid={1}&Uid={2}&Ti={3}", s_Counter, s_strSessionID, s_userID, s_strTime);
		s_Counter++;
	}

	public void SetHeadBuffer(byte[] buffer){
		_headBuffer = buffer;
	}

	public void SetBodyData(byte[] buffer){
		_bodyBuffer = buffer;
	}

	private byte[] GetDataBuffer(){
		if(null != _headBuffer || null != _bodyBuffer || _headBuffer.Length == 0){
			return new byte[0];
		}

		byte[] lenBytes = BitConverter.GetBytes(_headBuffer.Length);
		byte[] buffer = new byte[lenBytes.Length + _headBuffer.Length + _bodyBuffer.Length];
		Buffer.BlockCopy(lenBytes, 0, buffer, 0, lenBytes.Length);
		Buffer.BlockCopy(_headBuffer, 0, buffer, lenBytes.Length, _headBuffer.Length);
		Buffer.BlockCopy(_bodyBuffer, 0, buffer, lenBytes.Length + _headBuffer.Length, _bodyBuffer.Length);

		return buffer;
	}
}
