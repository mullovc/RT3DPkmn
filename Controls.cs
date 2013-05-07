using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	public CameraRotation camRotation;
	public Movement movement;
	public Pokemon pokemon;
	public Pokemon opponent;
	
	float buttonCooler;
	public string lastKey;
	
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
				pokemon.stats.move[0].triggerAttack();
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if(Input.GetKeyDown("left") || GUILayout.Button(pokemon.stats.move[1].Name))
			{
				pokemon.stats.move[1].triggerAttack();
			}
			if(Input.GetKeyDown("right") || GUILayout.Button(pokemon.stats.move[2].Name))
			{
				pokemon.stats.move[2].triggerAttack();
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Space(Screen.width/16);
			if(Input.GetKeyDown("down") || GUILayout.Button(pokemon.stats.move[3].Name,GUILayout.Width(Screen.width/8)))
			{
				pokemon.stats.move[3].triggerAttack();
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
	
	bool determineDoubleTap()
	{
		if(Input.anyKeyDown)
		{
			if(lastKey != "" && buttonCooler > 0)
			{
				if(Input.GetKeyDown(lastKey))
				{
					return true;
				}
			}
			if(Input.GetKeyDown("w"))
				lastKey = "w";
			else if(Input.GetKeyDown("a"))
				lastKey = "a";
			else if(Input.GetKeyDown("s"))
				lastKey = "s";
			else if(Input.GetKeyDown("d"))
				lastKey = "d";
			else
				lastKey = "";
			
			buttonCooler = 0.3f;
		}
		
		if(buttonCooler > 0)
			buttonCooler -= Time.deltaTime;
		
		return false;
	}
	
	void walk()
	{/*
		if(Input.GetKey("w"))
		{
			movement.speed += Vector3.forward * Time.deltaTime * pokemon.walkSpeed;
		}
		if(Input.GetKey("a"))
		{
			movement.speed += Vector3.left * Time.deltaTime * pokemon.walkSpeed;
		}
		if(Input.GetKey("s"))
		{
			movement.speed += Vector3.back * Time.deltaTime * pokemon.walkSpeed;
		}
		if(Input.GetKey("d"))
		{
			movement.speed += Vector3.right * Time.deltaTime * pokemon.walkSpeed;
		}*/
		Vector3 movementDirection = Vector3.zero;
		if(Input.GetKey("w"))
		{
			movementDirection += Vector3.forward;
		}
		if(Input.GetKey("a"))
		{
			movementDirection += Vector3.left;
		}
		if(Input.GetKey("s"))
		{
			movementDirection += Vector3.back;
		}
		if(Input.GetKey("d"))
		{
			movementDirection += Vector3.right;
		}
		movement.triggerMovement(movementDirection,pokemon.walkSpeed,Time.deltaTime);
	}
	
	
	void Update ()
	{
		if(determineDoubleTap())
		{
			Vector3 dashDirection = Vector3.zero;
			switch(lastKey)
			{
				case "w":
					dashDirection = Vector3.forward;
					break;
				case "a":
					dashDirection = Vector3.left;
					break;
				case "s":
					dashDirection = Vector3.back;
					break;
				case "d":
					dashDirection = Vector3.right;
					break;
			}
			movement.triggerDash(dashDirection,pokemon.dashSpeed,pokemon.dashDuration,false);
		}
		walk();
	}
}
