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
		
	}
	
	void OnGUI()
	{
		if(camRotation.lockOnEnemy)
		{
			GUI.skin.box.fontSize = 12;
			GUI.skin.box.stretchHeight = true;
			GUI.skin.box.alignment = TextAnchor.MiddleCenter;
			
			GUILayout.BeginArea(new Rect(Screen.width * 0.75f,Screen.height * (5f/6f),Screen.width / 4,Screen.height / 6));
			GUILayout.BeginHorizontal();
			
			GUILayout.Space(Screen.width * (1f/32f));
			GUILayout.Box("Q",GUILayout.Width(Screen.width * (5f/96f)));
			GUILayout.Box(pokemon.stats.move[1].Name);
			GUILayout.Box("E",GUILayout.Width(Screen.width * (5f/96f)));
			GUILayout.Space(Screen.width * (1f/32f));
			
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			
			GUILayout.Box(pokemon.stats.move[2].Name);
			GUILayout.Box(pokemon.stats.move[3].Name);
			GUILayout.Box(pokemon.stats.move[4].Name);
			
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		
		GUI.skin.box.stretchHeight = false;
		
		GUILayout.BeginArea(new Rect(0,0,Screen.width / 6,Screen.height / 6));
		
		GUILayout.Label("Lv." + pokemon.stats.level + " " + pokemon.Name);
		GUILayout.Box(pokemon.stats.HP + "/" + pokemon.stats.maxHP,											//-->
		GUILayout.Width((float)pokemon.stats.HP / (float)pokemon.stats.maxHP * (Screen.width/6)));
		GUILayout.Box("",GUILayout.Width((float)pokemon.stats.exp / (float)pokemon.stats.expToNextLevel * (Screen.width/6)),GUILayout.Height(5));
		
		GUILayout.EndArea();
		
		if(camRotation.lockOnEnemy)
		{
			GUILayout.BeginArea(new Rect(Screen.width * (5f/6f),0,Screen.width / 6,Screen.height / 6));
			
			GUILayout.Label("Lv." + opponent.stats.level + " " + opponent.Name);
			GUILayout.Box(opponent.stats.HP + "/" + opponent.stats.maxHP,									//-->
			GUILayout.Width((float)opponent.stats.HP / (float)opponent.stats.maxHP * (Screen.width/6)));
			
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
	
	void getWalkInput()
	{
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
	
	void getAttackInput()
	{
		if(Input.GetKeyDown("q"))
		{
			
		}
		if(Input.GetKeyDown("up") && pokemon.stats.move[1].Name != "")
		{
			pokemon.stats.move[1].cast();
		}
		if(Input.GetKeyDown("e"))
		{
			pokemon.stats.move[0].cast();
		}
		if(Input.GetKeyDown("left") && pokemon.stats.move[2].Name != "")
		{
			pokemon.stats.move[2].cast();
		}
		if(Input.GetKeyDown("right") && pokemon.stats.move[3].Name != "")
		{
			pokemon.stats.move[3].cast();
		}
		if(Input.GetKeyDown("down") && pokemon.stats.move[4].Name != "")
		{
			pokemon.stats.move[4].cast();
		}
	}
	
	void Update ()
	{
		if(determineDoubleTap())
		{
			Vector3 dodgeDirection = Vector3.zero;
			switch(lastKey)
			{
				case "w":
					dodgeDirection = Vector3.forward;
					break;
				case "a":
					dodgeDirection = Vector3.left;
					break;
				case "s":
					dodgeDirection = Vector3.back;
					break;
				case "d":
					dodgeDirection = Vector3.right;
					break;
			}
			movement.triggerDodge(dodgeDirection,pokemon.dashSpeed,pokemon.dashDuration);
		}
		getWalkInput();
		if(camRotation.lockOnEnemy)
			getAttackInput();
		if(opponent == null && transform.GetComponent<Battle>().opponent != null)
		{
			opponent = transform.GetComponent<Battle>().opponent;
		}
	}
}
