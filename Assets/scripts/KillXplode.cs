using UnityEngine;
using System.Collections;

public class KillXplode : MonoBehaviour {

	public float timer = 1f;

	// Use this for initialization
	void Start () {
		Invoke("Die",timer);
	}
	
	// Update is called once per frame
	void Die () {
		Destroy(gameObject);
	}
}
