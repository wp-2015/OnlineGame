using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageHead : MonoBehaviour {

	public PackageHead(int actionId){
		this.ActionId = actionId;
	}

	public int StatusCode{get;set;}

	public string Description{get;set;}

	public int ActionId{get;set;}

	public int MsgId{get;set;}

	public string SessionId{get;set;}

	public int UserId{get;set;}

	public string Time{get;set;}
}
