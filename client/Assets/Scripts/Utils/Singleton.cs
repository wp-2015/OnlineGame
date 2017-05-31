using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{

	private static T instance;

	public static T Instance{
		get{
			if(null == instance){
				instance = (T)FindObjectOfType(typeof(T));

				if(null == instance){
					Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
				}
			}
			return instance;
		}
	}
}