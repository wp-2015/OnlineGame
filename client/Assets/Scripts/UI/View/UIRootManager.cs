using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PageInfo{
	public string szPageName;
	public GameObject goView;
}

public class UIRootManager : MonoBehaviour {

	public List<PageInfo> listPage;

	public void ShowPage(string szPageName){
		foreach(var pageInfo in listPage){
			if(pageInfo.szPageName.Equals(szPageName)){
				pageInfo.goView.SetActive(true);
			}else{
				pageInfo.goView.SetActive(false);
			}
		}
	}
}
