using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class LoadUIRoot : SimpleCommand {

	public override void Execute(INotification notification){
		GameObject goRoot = Utils.LoadUIResource("UI/UI Root");
		LoginRegister login = goRoot.GetComponentInChildren<LoginRegister>();
		if(null != login){
			Facade.RegisterMediator(new LoginRegisterMediator(login));
		}
	}
}
