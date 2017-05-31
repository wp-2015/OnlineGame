using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class UIRootManagerMediator : Mediator {

	public const string SIGN = "UIRootManagerMediator";

	public UIRootManagerMediator(UIRootManager view) : base(SIGN, view){
		Facade.RegisterCommand(CommandName.CHANGEPAGE, typeof(ChangeUIPage));
	}
}
