using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginRegister : MonoBehaviour {

	public UIButton btLogin;
	public UIButton btRegister;

	public Action actionLogin;
	public Action actionRegister;

	void Awake(){
	}

	public void login(){
		if(null != actionLogin){
			actionLogin();
		}
	}

	public void register(){
		Debug.Log("register.....");
		if(null != actionRegister){
			actionRegister();
		}
	}
}
