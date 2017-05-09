using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartUp : SimpleCommand {

	public override void Execute(INotification notification){
		GameObject go = (GameObject)notification.Body as GameObject;
		go.AddComponent<GameManager>();
		go.AddComponent<SocketManager>();
		go.AddComponent<Utils>();
	}
}
