using System;
using System.Collections;
using UnityEngine;

public class Net : MonoBehaviour, IHttpCallBack{

	public enum Status{
		eStartRequest = 0,
		eEndRequest,
	}

	public enum eNetError{
		eConnectFailed = 0,
		eTimeOut,
	}

	public delegate bool CanRequestDelegate(int actionId, ActionParam actionParam);
	public delegate void RequestNotifyDelegate(Status eStatus);

	// 网络请求回调统一处理方法
	public delegate bool CommonDataCallback(NetReader reader);

	protected static readonly int OVER_TIME = 30;
	private const int NETSUCCESS = 0;

	private string strUrl;

	private ServerConnect mSocket = null;

	private static Net s_instance = null;
	public static Net Instance{
		get{
			s_instance = UnityEngine.Object.FindObjectOfType(typeof(Net)) as Net;
			if (s_instance == null){
				GameObject obj2 = new GameObject("net");
				s_instance = obj2.AddComponent(typeof(Net)) as Net;
				if (s_instance != null){
					s_instance.RequestNotify = s_instance.RequestDelegate;
					s_instance.HeadFormater = new DefaultHeadFormater();
					s_instance.NetErrorCallback = (type, id, msg) => Debug.LogError(string.Format("Net error:{0}-{1}", id, msg));
				}
			}
			return s_instance;
		}
	}

	public IHeadFormater HeadFormater { get; set; }

	/// <summary>
	/// 请求代理通知
	/// </summary>
	public RequestNotifyDelegate RequestNotify { set; get; }

	/// <summary>
	/// 注册网络请求出错回调方法
	/// </summary>
	public NetError NetErrorCallback { get; set; }

	/// <summary>
	/// 注册网络请求回调统一处理方法
	/// </summary>
	public CommonDataCallback CommonCallback { get; set; }

	/// <summary>
	/// 网络请求出错回调方法
	/// </summary>
	/// <param name="nType"></param>
	/// <param name="actionId"></param>
	/// <param name="strMsg"></param>
	public delegate void NetError(eNetError nType, int actionId, string strMsg);

	public void OnPushCallback(SocketPackage package){
		try{
			if(null == package) return;

			//心跳
			if(package.ActionId == 1) return;

			GameAction gameAction = ActionFactory.Create(package.ActionId);

			if(null == gameAction){
				throw new ArgumentException(string.Format("Not found {0} of GameAction object.", package.ActionId));
			}

			NetReader reader = package.reader;
			bool result = true;

			if(null != CommonCallback){
				result = CommonCallback(reader);
			}

			if(result && gameAction.TryDecodePackage(reader)){
				ActionResult actionResult = gameAction.GetResponseData();
				gameAction.OnCallback(actionResult);
			}else{
				Debug.Log("Decode package fail.");
			}

		}catch(Exception ex){
			Debug.LogException(ex);
		}
	}

	public void RequestDelegate(Net.Status state){
		
	}

	public void Awake(){
		UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
	}

	void Update(){
		if(null != mSocket){
			mSocket
		}
	}
}

