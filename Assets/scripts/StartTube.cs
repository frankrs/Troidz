using UnityEngine;
using System.Collections;

public class StartTube : MonoBehaviour {

	public float tiltSpeed = 1f;
	public float throughSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float off = renderer.material.mainTextureOffset.x;
		off = (Time.deltaTime * tiltSpeed) + off;
		float offT = renderer.material.mainTextureOffset.y;
		offT = (Time.deltaTime * throughSpeed) + offT;
		renderer.material.mainTextureOffset = new Vector2(off,offT);
	}
}
