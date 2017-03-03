using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

	public InputField textInput;
	public Transform transformParent;
	public GameObject gameobjectText;

	public Client client;

	public void addTextToView(string content){
		if(null != transformParent && null != gameobjectText){
			GameObject goText = Instantiate<GameObject>(gameobjectText);
			goText.GetComponent<Text>().text = content;
			goText.transform.SetParent(transformParent);
			if(transformParent.childCount > 10){
				Transform transformChild = transformParent.FindChild("text(Clone)");
				if(null != transformChild){
					Destroy(transformChild.gameObject);
				}
			}
		}
	}

	public void clickButtonToAddText(){
		if(null != textInput && !textInput.text.Equals("") && null != client){
			addTextToView(textInput.text);

			client.Send(textInput.text);

//			textInput.text = "";
		}
	}
}
