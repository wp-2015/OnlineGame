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

	public NetWriter(){
		resetData();
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

	public void WriteInt32(string szKey, int nValue){
		s_strUserData += string.Format("&{0}={1}", szKey, nValue);
	}

	public void writeFloat(string szKey, float fvalue){
		s_strUserData += string.Format("&{0}={1}", szKey, fvalue);
	}

	public void writeString(string szKey, string szValue){
		if(null == szValue){
			return;
		}
		s_strUserData += string.Format("&{0}=", szKey);
		s_strUserData += url_encode(szValue);
	}

	public void writeInt64(string szKey, string szValue){
		s_strUserData += string.Format("&{0}={1}", szKey, szValue);
	}

	public void writeWord(string szKey, UInt16 sValue){
		s_strUserData += string.Format("&{0}={1}", szKey, sValue);
	}

	public static void SetUrl(string szUrl){
		SetUrl(szUrl, ResponseContentType.Stream);
	}

	public static void SetUrl(string szUrl, ResponseContentType respContentType, bool bIsGet = false){
		s_strUrl = szUrl;
		IsGet = bIsGet;
		_respContentType = respContentType;
	}

	public static string GetUrl(){
		return s_strUrl;
	}

	public static bool IsSocket(){
		if(null != s_strUrl && !s_strUrl.Contains("http")){
			return true;
		}
		return false;
	}

	public static string getMd5String(byte[] buf){
		return Encryption.MD5Conversion(buf);
	}

	public static string getMd5String(string input)
	{
		return getMd5String(Encoding.Default.GetBytes(input));
	}

	public string url_encode(string str){
		return WWW.EscapeURL(str);
	}

	public byte[] PostData(){
		byte[] data;
		if(null != _headBuffer && _headBuffer.Length > 0){
			data = GetDataBuffer();
		}else if(_respContentType == ResponseContentType.Json){
			s_strPostData = s_strUserData + "&sign=" + getMd5String(s_strUserData + s_md5Key);
			data = Encoding.UTF8.GetBytes(s_strPostData);
		}else{
			s_strPostData = IsSocket() ? "?d=" : "d=";
			string str = s_strUserData + "&sign=" + getMd5String(s_strUserData + s_md5Key);
			s_strPostData += url_encode(str);
			data = Encoding.ASCII.GetBytes(s_strPostData);
		}
		if(!IsSocket()) return data;

		byte[] len = BitConverter.GetBytes(data.Length);
		byte[] sendBytes = new byte[data.Length + len.Length];
		Buffer.BlockCopy(len, 0, sendBytes, 0, len.Length);
		Buffer.BlockCopy(data, 0, sendBytes, len.Length, data.Length);
		return sendBytes;
	}
}
