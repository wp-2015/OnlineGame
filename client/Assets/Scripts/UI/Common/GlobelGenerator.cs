using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobelGenerator : MonoBehaviour {

	void Awake(){
		InitGameManager();
	}

	/// <summary>
	/// 添加 GameManager 物体
	/// </summary>
	public void InitGameManager(){
		string name = "GameManager";
		GameObject manager = GameObject.Find(name);
		if(null == manager){
			manager = new GameObject(name);
			manager.name = name;

			ApplicationFacade facade = ApplicationFacade.Instance as ApplicationFacade;
			facade.SetUp(manager);
		}
	}
}
