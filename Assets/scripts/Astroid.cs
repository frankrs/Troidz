using UnityEngine;
using System.Collections;

public class Astroid : MonoBehaviour {


	public GameManager gameM;

	public Quaternion rot;

	public GameObject xplosion;
	
	


	void Start () {
	// get random rotation
		rot = Random.rotation;

	}
	
	// Update is called once per frame
	void Update () {
		// move astroid along
		transform.Translate(new Vector3(0f,0f,Time.deltaTime * -gameM.speed),Space.World);

		// rotate astroid
		transform.Rotate(rot.eulerAngles * Time.deltaTime);

		// destroy if missed
		if(transform.position.z < -150f){
			Destroy (gameObject);
		}
	}

	void OnParticleCollision(){
		BlowUp ();
	}


	public void BlowUp (){
		gameM.AddScore(10);
		Instantiate(xplosion,new Vector3(transform.position.x,transform.position.y +1,transform.position.z),Quaternion.Euler(90f,0f,0f));
		Destroy(gameObject);
	}

	void Launch (GameManager gm){
		gameM = gm;
	}
}
