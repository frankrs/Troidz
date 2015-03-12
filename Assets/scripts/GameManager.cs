using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Renderer background;

	public float speed = 1 ;

	//public float tFloat ;

	public GameObject astroid;

	public GameObject inHand;

	public GameObject[] goodies;
	public int listIndex = 0;

	public float rate = 3f;

	public float timer;


	private float left;
	private float right;
	
	public float accelRate = 1f;

	public int score = 0;
	public GUIText scoreboard;
	
	// Use this for initialization
	void Start () {
		timer = rate;
		left = Camera.main.ViewportToWorldPoint(new Vector3(0,0,180)).x;
		right = Camera.main.ViewportToWorldPoint(new Vector3(1,0,180)).x;
		InvokeRepeating("SwapObject",10f,10f);
		inHand = astroid;
	}
	

	void Update () {

		// accelerate 

		speed = speed + Time.deltaTime;
		speed = Mathf.Clamp(speed,0f,160f);


		// increase rate
		rate = rate - (Time.deltaTime * .05f);
		rate = Mathf.Clamp(rate,.2f,4f);

		// scroll the background texture
		float offset = background.material.mainTextureOffset.y;
		offset = offset + (Time.deltaTime * speed * .01f);
		background.material.mainTextureOffset = new Vector2 (0f,offset);

		// test moving astroid
		//astroid.transform.Translate(new Vector3(0f,0f,Time.deltaTime * -speed),Space.World);

		//drop astroids according to timer
		timer = timer - Time.deltaTime;
		if(timer <=0){
			DropAstroid();
		}

	}


	void DropAstroid (){
		timer = rate;
		GameObject ast;
		ast = GameObject.Instantiate(inHand,new Vector3(Random.Range(left,right),0f,125f),Quaternion.identity) as GameObject;
		//ast.GetComponent<Astroid>().gameM = this;
		ast.SendMessage("Launch",this);
		inHand = astroid;
	}


	public void AddScore(int i){
		score = score + i;
		scoreboard.text = "Score "+score;
	}

	public void GameOver (){
		var gui = GetComponent<GUIScript>();
		gui.score = score;
		gui.gameOver = true;
		gui.enabled = true;
	}



	void SwapObject (){
		if(listIndex == 2){
			listIndex = 0;
		}
		else{
			listIndex ++;
		}
		inHand = goodies[listIndex];
	}
}
