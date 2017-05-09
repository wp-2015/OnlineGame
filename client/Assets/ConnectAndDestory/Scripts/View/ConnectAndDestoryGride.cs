using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectAndDestoryGride : MonoBehaviour {

	private UISprite facadeSprite;
	private UISprite FacadeSprite{
		get{
			if(null == facadeSprite){
				facadeSprite = gameObject.GetComponent<UISprite>();
			}
			return facadeSprite;
		}
	}
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

//	public void 
}
