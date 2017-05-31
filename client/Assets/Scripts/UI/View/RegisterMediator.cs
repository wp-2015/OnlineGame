using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class RegisterMediator : Mediator {

	public const string SIGN = "RegisterMediator";

	public Register registerView;

	public RegisterMediator(Register view) : base(SIGN, view){
		this.registerView = view;
		view.actionSubmit += submit;
	}

	void submit(){
		Debug.Log("submit");

		onl.User user = new onl.User();
		user.account = 123123;
		user.password = "456456";
		user.nickname = "snowball";

		SocketManager.Instance.SendData<onl.User>(ClientSendType.REGISTER, user);
	}
}
