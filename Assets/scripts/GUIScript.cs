using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public Rect guiRect;

	public GUISkin skin;


	public bool gameOver ;
	public int score;
	
	
	// Use this for initialization
	void Start () {
		guiRect.height = Screen.height;
		guiRect.width = Screen.width*.75f;
		guiRect.x = Screen.width/8;
		guiRect.y = Screen.height/4;
	}



	public void Pause (){
		if(gameOver){
			return;
		}
		if(Time.timeScale < 1f){
			Cont ();
			return;
		}
		Time.timeScale = 0f;
		this.enabled = true;
	}
	
	void OnGUI (){
		GUI.skin = skin;
		GUILayout.BeginArea(guiRect);
		if(gameOver == false){
			GUILayout.Box("Paused",GUILayout.Height(Screen.height/8));
			if(GUILayout.Button("Continue",GUILayout.Height(Screen.height/8))){
				Cont ();
			}
			if(GUILayout.Button("Menu",GUILayout.Height(Screen.height/8))){
				Time.timeScale = 1f;
				Application.LoadLevel(0);
			}
			if(GUILayout.Button("Exit",GUILayout.Height(Screen.height/8))){
				Application.Quit();
			}
		}
		else{
			//GUILayout.Label("Game Over",GUILayout.Height(Screen.height/8),GUILayout.Width(Screen.width));
			//GUILayout.Box("Score" + score,GUILayout.Height(Screen.height/8));
			if(GUILayout.Button("TryAgain",GUILayout.Height(Screen.height/8))){
				Time.timeScale = 1f;
				Application.LoadLevel(1);
			}
			if(GUILayout.Button("Menu",GUILayout.Height(Screen.height/8))){
				Time.timeScale = 1f;
				Application.LoadLevel(0);
			}
//			if(GUILayout.Button("Exit",GUILayout.Height(Screen.height/8))){
//				Application.Quit();
//			}
		}
		GUILayout.EndArea();
	}

	void Cont (){
		Time.timeScale = 1f;
		this.enabled = false;
	}








}
