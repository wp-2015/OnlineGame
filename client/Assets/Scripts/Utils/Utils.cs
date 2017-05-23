using System;
using UnityEngine;

public class Utils : MonoBehaviour{

	public static bool IsNull(object obj){
		if(null != obj){
			return false;
		}else{
			Debug.Log("the obj : " + obj.GetType().Name + " is null!!!");
		}
		return true;
	}

	public static GameObject LoadUIResource(string path, Transform tfParent = null){
		GameObject go = Instantiate<GameObject>(Resources.Load(path) as GameObject);
		if(null != go && null != tfParent){
			go.transform.SetParent(tfParent);
		}else if(null == go){
			Debug.Log("the go " + path + "is null");
		}
		return go;
	}
}
