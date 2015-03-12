using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Rect instRect ;

	public Rect guiRect;
	
	public GUISkin skin;

	public Texture inst;

	public Vector2 scrollPosition;
	
	public TitleState titleState = TitleState.menu;
	public enum TitleState{
		menu,
		instructions
	}


	void Update (){
		if(Input.GetKeyDown("escape")){
			if(titleState == TitleState.instructions){
				titleState = TitleState.menu;
			}
			else{
				Application.Quit();
			}
		}

	}

	// Use this for initialization
	void Start () {
		guiRect.height = Screen.height/2;
		guiRect.width = Screen.width/2;
		guiRect.x = Screen.width/4;
		guiRect.y = Screen.height/2;

		instRect.height = Screen.height * .75f;
		instRect.width = Screen.width * .75f;
		instRect.x = Screen.width/8;
		instRect.y = Screen.height/8;
	}

	void OnGUI (){
		GUI.skin = skin;
		if(titleState == TitleState.menu){
			GUILayout.BeginArea(guiRect);
			//GUILayout.Box("Astroid Belt",GUILayout.Height(Screen.height/8));
			if(GUILayout.Button("Play",GUILayout.Height(Screen.height/8))){
				Application.LoadLevel(1);
			}
			if(GUILayout.Button("Guide",GUILayout.Height(Screen.height/8))){
				titleState = TitleState.instructions;
			}
			if(GUILayout.Button("Exit",GUILayout.Height(Screen.height/8))){
				Application.Quit();
			}
			GUILayout.EndArea();
		}
		if(titleState == TitleState.instructions){
			GUILayout.BeginArea(instRect);
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(instRect.width), GUILayout.Height(instRect.height-Screen.height/6));
				GUILayout.Label(inst);
				GUILayout.EndScrollView();
			if(GUILayout.Button("Back",GUILayout.Height(Screen.height/8))){
				titleState = TitleState.menu;
			}
			GUILayout.EndArea();
		}
	}
}
