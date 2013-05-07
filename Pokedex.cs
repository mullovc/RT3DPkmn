using UnityEngine;
using System.Collections;

public class Pokedex : MonoBehaviour {
	
	float xAxisModifier = Screen.width / 1366f;
	
	public GameObject[] model = new GameObject[500];
	public GameObject[] moveModel = new GameObject[500];
	
	void Start ()
	{
	}
	
	public enum Type
	{
		None,
		Normal,
		Fight,
		Rock,
		Ground,
		Unlight,
		Ghost,
		Bug,
		Fire,
		Water,
		Plant,
		Electric,
		Psycho,
		Metal,
		Dragon,
		Flight,
		Poison
	}
	
	public Pokemon pokedex(Pokemon pokemon,int index,bool yourself = true)
	{
		switch(index)
		{
			case 6:
				pokemon.Name = "Glurak";
				pokemon.type1 = Type.Fire;
				pokemon.type2 = Type.Flight;
				pokemon.dashSpeed = 4;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-11 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 25:
				pokemon.Name = "Pikachu";
				pokemon.type1 = Type.Electric;
				pokemon.type2 = Type.None;
				pokemon.dashSpeed = 2;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 20;
				pokemon.height = 3.3f;
				pokemon.learnableMoves[2] = 1;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-4 * xAxisModifier,pokemon.height * 1.5f,-6);
				}
				break;
			case 93:
				pokemon.Name = "Alpollo";
				pokemon.type1 = Type.Ghost;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 4;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-11 * xAxisModifier,pokemon.height * 1.5f,-14);
				}
				break;
			case 151:
				pokemon.Name = "Mew";
				pokemon.type1 = Type.Psycho;
				pokemon.type2 = Type.None;
				pokemon.dashSpeed = 2;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 20;
				pokemon.height = 2.3f;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-4 * xAxisModifier,pokemon.height * 1.5f + 7,-6);
				}
				break;
			case 149:
				pokemon.Name = "Dragoran";
				pokemon.type1 = Type.Dragon;
				pokemon.type2 = Type.Electric;
				pokemon.dashSpeed = 4;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-11);
				}
				break;
			case 212:
				pokemon.Name = "Scherox";
				pokemon.type1 = Type.Metal;
				pokemon.type2 = Type.Bug;
				pokemon.dashSpeed = 3;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 30;
				pokemon.height = 11;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 248:
				pokemon.Name = "Despotar";
				pokemon.type1 = Type.Ground;
				pokemon.type2 = Type.Unlight;
				pokemon.dashSpeed = 4;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-11);
				}
				break;
			case 257:
				pokemon.Name = "Lohgock";
				pokemon.type1 = Type.Fire;
				pokemon.type2 = Type.Fight;
				pokemon.dashSpeed = 3;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 30;
				pokemon.height = 13;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-9);
				}
				break;
			case 321:
				pokemon.Name = "Wailord";
				pokemon.type1 = Type.Water;
				pokemon.type2 = Type.None;
				pokemon.dashSpeed = 5;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 50;
				pokemon.height = 25;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-35 * xAxisModifier,pokemon.height * 1.5f,-40);
				}
				break;
			case 376:
				pokemon.Name = "Metagross";
				pokemon.type1 = Type.Metal;
				pokemon.type2 = Type.None;
				pokemon.dashSpeed = 4;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-12 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 383:
				pokemon.Name = "Groudon";
				pokemon.type1 = Type.Fire;
				pokemon.type2 = Type.Ground;
				pokemon.dashSpeed = 5;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 50;
				pokemon.height = 25;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-19 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 384:
				pokemon.Name = "Rayquaza";
				pokemon.type1 = Type.Dragon;
				pokemon.type2 = Type.Flight;
				pokemon.dashSpeed = 5;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 50;
				pokemon.height = 5;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-11);
				}
				break;
			case 386:
				pokemon.Name = "Deoxys";
				pokemon.type1 = Type.Psycho;
				pokemon.type2 = Type.None;
				pokemon.dashSpeed = 4;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-12 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 491:
				pokemon.Name = "Darkrai";
				pokemon.type1 = Type.Psycho;
				pokemon.type2 = Type.None;
				pokemon.dashSpeed = 4;
				pokemon.dashDuration = 0.75f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
		}
		
		pokemon.index = index;
		if(model[index] != null)
		{
			pokemon.model = Instantiate(model[index]) as GameObject;
			pokemon.model.transform.parent = pokemon.transform;
			pokemon.model.transform.position = pokemon.transform.position;
			pokemon.model.transform.rotation = pokemon.transform.rotation;
		}
		
		return pokemon;
	}
	
	
	public Move movedex(Move move,int index)
	{
		switch(index)
		{
			case 1:
				move.Name = "Tackle";
				move.type1 = Type.Normal;
				move.type2 = Type.None;
				move.damage = 40;
				break;
		}
		
		move.index = index;
		if(moveModel[index] != null)
		{
			move.model = moveModel[index];
		}
		return move;
	}
	
	void Update () {
	
	}
}
