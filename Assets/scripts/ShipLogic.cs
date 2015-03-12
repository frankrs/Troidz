using UnityEngine;
using System.Collections;

public class ShipLogic : MonoBehaviour {

	public ParticleSystem gun;

	public GameManager manager;

	public Renderer forceField;

	public GameObject xplosion;

	public float starTimer = 5f;

	public Renderer shipRenderer;

	public Material normMat;

	public Material starMat ;

	public AudioSource radio;


	public AudioClip FF ;

	public AudioClip star;

	public ShipState shipState;
	public enum ShipState{
		normal,
		shielded,
		invincable
	}

	void Awake (){
		normMat = shipRenderer.material;
	}

	void Update () {
	//fire gun
	foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				if(Time.timeScale > 0){
				gun.Emit(1);
					audio.Play();
				}
			}
		}
	}


	// look to see if ship is struck
	void OnTriggerEnter (Collider col){
		if(col.tag == "Astroid"){
			if(shipState == ShipState.normal){
				manager.SendMessage("GameOver",SendMessageOptions.DontRequireReceiver);
				Instantiate(xplosion,new Vector3(transform.position.x,transform.position.y +1,transform.position.z),Quaternion.Euler(90f,0f,0f));
				radio.pitch = 1f;
				Destroy(gameObject);
			}
			if(shipState == ShipState.shielded){
				col.SendMessage("BlowUp");
				ShieldDown();
			}
			if(shipState == ShipState.invincable){
				col.SendMessage("BlowUp");
			}
		}
		if(col.tag == "Shield"){
			ShieldOn();
			col.SendMessage("BlowUp");
		}
		if(col.tag == "Star"){
			StarOn();
			col.SendMessage("BlowUp");
		}
	}


	void ShieldDown (){
		shipState = ShipState.normal;
		forceField.enabled = false;
	}

	void ShieldOn (){
		AudioSource.PlayClipAtPoint(FF,new Vector3(0f,0f,0f));
		shipState = ShipState.shielded;
		forceField.enabled = true;
	}

	void StarOn (){
		AudioSource.PlayClipAtPoint(star,new Vector3(0f,0f,0f));
		ShieldDown();
		starTimer = 5f;
		shipState = ShipState.invincable;
		radio.pitch = 1.25f;
		StartCoroutine("TimeStar");
		InvokeRepeating("Blink",.2f,.2f);
	}

	void StarDown () {
		CancelInvoke("Blink");
		radio.pitch = 1f;
		shipRenderer.material = normMat;
		if(shipState == ShipState.invincable){
			shipState = ShipState.normal;
		}
	}

	IEnumerator TimeStar(){
		while(starTimer > 0 && shipState == ShipState.invincable){
			starTimer = starTimer - Time.deltaTime;
			yield return null;
		}
		StarDown();
	}

	void Blink (){
		if(shipRenderer.material == normMat){
			shipRenderer.material = starMat;
		}
		else{
			shipRenderer.material = normMat;
		}
	}

}
