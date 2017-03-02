using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameAction {

	private readonly int _actionId;

	public PackageHead Head{get;private set;}

	protected GameAction(int actionId){
		Head = new PackageHead(actionId);
	}

	public int ActionId{
		get{
			if(null != Head){
				return Head.ActionId;
			}
			return -1;
		}
	}

	public event Action<ActionParam> Callback;

	public byte[] Send(ActionParam actionParam){
		NetWriter writer = NetWriter.Instance;
		SetActionHead(writer);
		SendParameter(writer, actionParam);
		return writer.PostData();
	}

	protected virtual void SetActionHead(NetWriter writer){
		if(null != writer){
			writer.WriteInt32("actionId", ActionId);
		}
	}

	protected abstract void SendParameter(NetWriter writer, ActionParam actionParam);

	// 尝试解Body包
	public bool TryDecodePackage(NetReader reader){
		try{
			DecodePackage(reader);
			return true;
		}catch(Exception ex){
			Debug.Log(string.Format("Action {0} decode package error:{1}", ActionId, ex));
			return false;
		}
	}

	protected abstract void DecodePackage(NetReader reader);

	public void OnCallback(ActionResult result){
		try{
			if(null != Callback){
				Callback(result);
			}
		}catch(Exception ex){
			Debug.Log(string.Format("Action {0} callback process error:{1}", ActionId, ex));
		}
	}

	public abstract ActionResult GetResponseData();

}
