using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class LoginRegisterMediator : Mediator {

	public const string SIGN = "LoginRegisterMediator";

	private LoginRegister loginView;

	public LoginRegisterMediator(LoginRegister view) : base(SIGN, view){
		this.loginView = view;
		view.actionLogin += OnLogin;
		view.actionRegister += OnRegisterInfo;
	}

	void OnLogin(){
		Debug.Log("login.");
	}

	void OnRegisterInfo(){
		Debug.Log("register");
		SendNotification(CommandName.CHANGEPAGE, loginView.transform.parent.gameObject, CommandName.REGISTER);
	}
}
