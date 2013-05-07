using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public CameraRotation camRotation;
	public Pokemon pokemon;
	public Pokemon opponent;
	
	void Start ()
	{
		opponent = Camera.main.GetComponent<Battle>().opponent;
	}
	
	void OnGUI()
	{
		if(camRotation.lockOnEnemy)
		{
			GUI.skin.button.fontSize = 20;
			GUI.skin.button.stretchHeight = true;
			GUILayout.BeginArea(new Rect(Screen.width*0.75f,Screen.height*0.75f,Screen.width/4,Screen.height/4));
			GUILayout.BeginHorizontal();
			GUILayout.Space(Screen.width/16);
			if(Input.GetKeyDown("up") || GUILayout.Button(pokemon.stats.move[0].Name,GUILayout.Width(Screen.width/8)))
			{
				pokemon.stats.move[0].attack();
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if(Input.GetKeyDown("left") || GUILayout.Button(pokemon.stats.move[1].Name))
			{
				pokemon.stats.move[1].attack();
			}
			if(Input.GetKeyDown("right") || GUILayout.Button(pokemon.stats.move[2].Name))
			{
				pokemon.stats.move[2].attack();
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Space(Screen.width/16);
			if(Input.GetKeyDown("down") || GUILayout.Button(pokemon.stats.move[3].Name,GUILayout.Width(Screen.width/8)))
			{
				pokemon.stats.move[3].attack();
			}
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		GUILayout.BeginArea(new Rect(0,0,Screen.width / 6,Screen.height / 6));
		
		GUILayout.Label("Lv." + pokemon.stats.level + " " + pokemon.Name);
		GUILayout.Box(pokemon.stats.HP + "/" + pokemon.stats.maxHP,											//-->
		GUILayout.Width((float)pokemon.stats.HP / (float)pokemon.stats.maxHP * 200f));
		GUILayout.Box(pokemon.stats.exp + "/" + pokemon.stats.expToNextLevel,								//-->
		GUILayout.Width((float)pokemon.stats.exp / (float)pokemon.stats.expToNextLevel * 200f));
		
		GUILayout.EndArea();
		
		if(camRotation.lockOnEnemy)
		{
			GUILayout.BeginArea(new Rect(Screen.width * (5f/6f),0,Screen.width / 6,Screen.height / 6));
			
			GUILayout.Label("Lv." + opponent.stats.level + " " + opponent.Name);
			GUILayout.Box(opponent.stats.HP + "/" + opponent.stats.maxHP,									//-->
			GUILayout.Width((float)opponent.stats.HP / (float)opponent.stats.maxHP * 200f));
			
			GUILayout.EndArea();
		}
	}
	
	void Update ()
	{
		
	}
}
