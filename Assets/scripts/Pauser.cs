using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {

	public GUIScript guiScript;

	void Update () {
		if(Input.GetKeyDown("escape")){
			guiScript.Pause();
		}
	}



}
