using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameAction {

	private readonly int _actionId;

	public PackageHead Head{get;private set;}

	protected GameAction(int actionId){
		Head = new PackageHead(actionId);
	}

	public int ActionId{
		get{
			if(null != Head){
				return Head.ActionId;
			}
			return -1;
		}
	}

	public event Action<ActionParam> Callback;

	public byte[] Send(ActionParam actionParam){
		
	}
}
