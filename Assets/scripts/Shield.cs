using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public GameManager gameM;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		// move astroid along
		transform.Translate(new Vector3(0f,0f,Time.deltaTime * -gameM.speed),Space.World);
		transform.Rotate(0f,0f,Time.deltaTime*180f);
		
		// destroy if missed
		if(transform.position.z < -150f){
			Destroy (gameObject);
		}
	}

	void Launch (GameManager gm){
		gameM = gm;
	}

	public void BlowUp (){
		gameM.AddScore(20);
		Destroy(gameObject);
	}
}
