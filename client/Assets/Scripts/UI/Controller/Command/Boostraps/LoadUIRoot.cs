using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class LoadUIRoot : SimpleCommand {

	public override void Execute(INotification notification){
		GameObject goRoot = Utils.LoadUIResource("UI/UI Root");
		LoadMediator(goRoot);

		SendNotification(CommandName.CHANGEPAGE, goRoot, CommandName.LOGIN);
	}

	public void LoadMediator(GameObject goRoot){
		if(null == goRoot){
			return;
		}

		UIRootManager root = goRoot.GetComponent<UIRootManager>();
		if(null != root){
			Facade.RegisterMediator(new UIRootManagerMediator(root));
		}

		Transform tfLogin = goRoot.transform.FindChild("LoginRegister");
		if(null != tfLogin){
			LoginRegister login = tfLogin.gameObject.GetComponent<LoginRegister>();
			Facade.RegisterMediator(new LoginRegisterMediator(login));
		}

		Transform tfRegister = goRoot.transform.FindChild("Register");
		if(null != tfRegister){
			Register register = tfRegister.gameObject.GetComponent<Register>();
			Facade.RegisterMediator(new RegisterMediator(register));
		}

	}
}
