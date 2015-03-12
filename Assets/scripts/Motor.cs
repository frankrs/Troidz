using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

	public float v;
	public float h;
	public float speed = 50f;


	public float top;
	public float bottom;
	public float left;
	public float right;


	private float zVelocity = 0.0F;
	public float smooth = 0.3F;

	// Use this for initialization
	void Start () {
		bottom = Camera.main.ViewportToWorldPoint(new Vector3(0,0,180)).z;
		top = Camera.main.ViewportToWorldPoint(new Vector3(0,1,180)).z;
		left = Camera.main.ViewportToWorldPoint(new Vector3(0,0,180)).x;
		right = Camera.main.ViewportToWorldPoint(new Vector3(1,0,180)).x;
	}
	
	// Update is called once per frame
	void Update () {
		// move ship with phone movement
		transform.Translate((new Vector3(v,0f,h)*Time.deltaTime*speed),Space.World);
		var pos = transform.position;
		pos.x = Mathf.Clamp(transform.position.x, left, right);
		pos.z = Mathf.Clamp(transform.position.z, bottom, top);
		transform.position = pos;

		// tilt ship when turning
		//transform.eulerAngles =  new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,(v * -45f));
		float zAngle =  Mathf.SmoothDampAngle(transform.eulerAngles.z,(v * -45f),ref zVelocity,smooth);
		transform.eulerAngles = new Vector3(0f,0f,zAngle);
	}
}
