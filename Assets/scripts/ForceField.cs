using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour {
	
	public float spinSpeed = 180;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,0f,Time.deltaTime * spinSpeed);
	}
}
