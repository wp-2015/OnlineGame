using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoginRegister : MonoBehaviour {

	public UIButton btLogin;
	public UIButton btRegister;

	public Action actionLogin;
	public Action actionRegister;

	public void login(){
		if(null != actionLogin){
			actionLogin();
		}
	}

	public void register(){
		if(null != actionRegister){
			actionRegister();
		}
	}
}
