using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace ConnectAndDestory{
//	public class Gride{
//		public int Row{get;set;}
//		public int Col{get;set;}
//	}
//}

public class ConnectAndDestoryPanel : MonoBehaviour {

	public int RowCount;
	public int ColCount;

	private ConnectAndDestoryGride[,] grideList;

	void Start(){
		grideList = new ConnectAndDestoryGride[RowCount,ColCount];
		InitPanel();
	}

	void InitPanel(){
		if(null == grideList){
			Debug.Log("grideRowList or grideColList is null");
			return;
		}

		int rowLength = 0;
		int colLength = 0;
//		foreach(var list in grideList){
//			foreach(var gride in list){
//				gride.transform.localPosition = new Vector3(colLength, rowLength);
//				rowLength += gride.Height;
//				colLength += gride.Width;
//			}	
//		}

		int xCenter = ColCount / 2;
		int yCenter = RowCount / 2;

		for(int i = 0; i < RowCount; i++){
			for(int j = 0; j < ColCount; j++){
				GameObject go = Instantiate<GameObject>(Resources.Load("ConnectAndDestory/Gride") as GameObject);
				if(null != go){
					grideList[i,j] = go.GetComponent<ConnectAndDestoryGride>();
				}
				go.transform.SetParent(this.transform, false);

				go.transform.
			}
		}

	}
}
