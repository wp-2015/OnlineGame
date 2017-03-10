using PureMVC.Patterns;
using UnityEngine;
using PureMVC.Interfaces;

public class ApplicationFacade : Facade{

	public new static IFacade Instance
	{
		get
		{
			if(m_instance == null)
			{
				lock(m_staticSyncRoot)
				{
					if (m_instance == null)
					{
						Debug.Log("ApplicationFacade");
						m_instance = new ApplicationFacade();
					}
				}
			}
			return m_instance;
		}
	}

	protected override void InitializeController(){
		base.InitializeController();
		RegisterCommand(CommandName.STARTUP, typeof(StartUp));
	}

	public void SetUp(GameObject goGameManager){
		SendNotification(CommandName.STARTUP, goGameManager);
		RemoveCommand(CommandName.STARTUP);
	}
}
