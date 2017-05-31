using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PureMVC.Patterns;

public class Register : MonoBehaviour {

	public UIButton btSubmit;
	public Action actionSubmit;

	public void OnSubmit(){
		if(null != actionSubmit){
			actionSubmit();
		}
	}
}
