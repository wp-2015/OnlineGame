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

	public string mapSizeConfig = "4,5\n2,1,1,1\n1,1,1\n1,1,1,2\n1,1,1";
	public string mapTexConfig = "4,5\n1,2,3,1\n1,3,1\n2,1,2,2\n2,3,1";

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

		float xLength = 0;
		float yLength = 0;

		for(int i = 0; i < RowCount; i++){
			for(int j = 0; j < ColCount; j++){
				GameObject go = Instantiate<GameObject>(Resources.Load("ConnectAndDestory/Gride") as GameObject);
				if(null != go){
					grideList[i,j] = go.GetComponent<ConnectAndDestoryGride>();
					go.transform.SetParent(this.transform, false);
					go.transform.localPosition = new Vector3(xLength, yLength);

					ConnectAndDestoryGride gride = go.GetComponent<ConnectAndDestoryGride>();
					if(null != gride){
						xLength += gride.Width;
						yLength += gride.Height;
					}
				}
			}
		}
	}
}
