using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class LoadUIRoot : SimpleCommand {

	public override void Execute(INotification notification){
		Utils.LoadUIResource("UI/UI Root");
	}
}
