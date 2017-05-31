using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class ChangeUIPage : SimpleCommand {

	public override void Execute(INotification notification){
		GameObject go = notification.Body as GameObject;
		if(null == go){
			return;
		}

		UIRootManager root = go.GetComponent<UIRootManager>();
		if(null != root){
			root.ShowPage(notification.Type);
		}
	}
}
