using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class LoginRegisterMediator : Mediator {

	public const string NAME = "LoginRegisterMediator";

	public LoginRegisterMediator(LoginRegister view) : base(NAME, view){
		view.actionLogin += login;
		view.actionRegister = register;
	}

	void login(){
		Debug.Log("login.");
	}

	void register(){
		Debug.Log("register");
	}
}
