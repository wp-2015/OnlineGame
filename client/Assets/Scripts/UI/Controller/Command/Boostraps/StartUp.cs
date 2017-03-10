using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

public class StartUp : SimpleCommand {

	public override void Execute(INotification notification){
		GameObject go = (GameObject)notification.Body as GameObject;
		go.AddComponent<GameManager>();
		go.AddComponent<SocketManager>();
	}
}
