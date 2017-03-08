using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class View : MonoBehaviour, IView {

	public virtual void OnMessage(IMessage message) {}
}
