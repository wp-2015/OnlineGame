using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectAndDestoryGride : MonoBehaviour {

	private UISprite FacadeSprite;
	public int Width{
		get{
			if(!Utils.IsNull(FacadeSprite)){
				return FacadeSprite.width;
			}
			return 0;
		}
	}
	public int Height{
		get{
			if(!Utils.IsNull(FacadeSprite)){
				return FacadeSprite.height;
			}
			return 0;
		}
	}

	void OnAwake(){
		InitProperites();
	}

	void InitProperites(){
		FacadeSprite = gameObject.GetComponent<UISprite>();
	}


}
