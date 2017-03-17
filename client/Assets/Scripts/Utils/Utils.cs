using System;
using UnityEngine;

public class Utils{

	public static bool IsNull(object obj){
		if(null != obj){
			return false;
		}else{
			Debug.Log("the obj : " + obj.GetType().Name + " is null!!!");
		}
		return true;
	}
}
