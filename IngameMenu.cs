using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour {
	
	bool menuIsOpen;
	
	
	void Start ()
	{
		Screen.lockCursor = true;
	}
	
	void OnGUI()
	{
		if(menuIsOpen)
			GUI.Window(0,new Rect(Screen.width / 3,Screen.height / 4,Screen.width / 3,Screen.height / 2),buildIngameMenuWindow,"Menu");
	}
	
	void buildIngameMenuWindow(int windowIndex)
	{
		GUI.skin.button.fontSize = 40;
		GUI.skin.button.stretchHeight = true;
		
		GUILayout.BeginArea(new Rect(0,20,Screen.width / 3,Screen.height / 2 - 20));
		
		if(GUILayout.Button("Resume"))
		{
			menuIsOpen = false;
			Screen.lockCursor = true;
		}
		if(GUILayout.Button("Character Selection"))
			Application.LoadLevel(0);
		GUILayout.Button("Cheats");
		
		GUILayout.Button("Settings");
		
		if(GUILayout.Button("Quit"))
			Application.Quit();
		
		GUILayout.EndArea();
	}
	
	void Update ()
	{
		if(Input.GetKeyDown("escape") && !menuIsOpen)
		{
			menuIsOpen = true;
			Screen.lockCursor = false;
		}
		else if(Input.GetKeyDown("escape") && menuIsOpen)
		{
			menuIsOpen = false;
			Screen.lockCursor = true;
		}
	}
}
