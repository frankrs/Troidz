using UnityEngine;
using System.Collections;

public class GameControlsMobile : MonoBehaviour {

	public float v = 0f;
	public float h = 0f;


	public Motor motor;




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID
		v = Input.acceleration.x;
		h = Input.acceleration.y;
#endif

#if UNITY_WEBPLAYER || UNITY_EDITOR
		v = Input.GetAxis("Horizontal") + Input.GetAxis("Mouse X");
		h = Input.GetAxis("Vertical") + Input.GetAxis("Mouse Y");;



#endif
		motor.v = v;
		motor.h = h;


	}



//	void OnGUI(){
//		GUILayout.BeginArea(new Rect(10,10,100,200));
//		GUILayout.Label(v.ToString());
//		GUILayout.Label(h.ToString());
//		GUILayout.EndArea();
//
//	}
}
