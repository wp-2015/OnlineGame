using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NetPackage {

	public int ErrorCode{get;set;}

	public int ActionId{get;set;}

	public GameAction Action{get;set;}

	public bool IsOverTime{get;set;}

	public string ErrorMsg{get;set;}

	public object UserData{get;set;}

	public NetReader reader{get;set;}
}
