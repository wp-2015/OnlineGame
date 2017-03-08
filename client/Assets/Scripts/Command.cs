using UnityEngine;
using System.Collections;

public class StartUpCommand : ControllerCommand {

	public override void Execute(IMessage message) {
		if (!Util.CheckEnvironment()) return;

		GameObject gameMgr = GameObject.Find("GlobalGenerator");
		//-----------------关联命令-----------------------
		AppFacade.Instance.RegisterCommand(NotiConst.DISPATCH_MESSAGE, typeof(SocketCommand));

		//-----------------初始化管理器-----------------------

		Debug.Log("SimpleFramework StartUp-------->>>>>");
	}
}