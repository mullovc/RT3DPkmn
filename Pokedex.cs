using UnityEngine;
using System.Collections;

public class Pokedex : MonoBehaviour {
	
	float xAxisModifier = Screen.width / 1366f;												//for different resolutions than 1266x738
	
	public GameObject[] model = new GameObject[500];
	public GameObject[] moveModel = new GameObject[100];
	
	void Start ()
	{
		
	}
	
	public enum Type
	{
		None,
		Normal,
		Fighting,
		Rock,
		Ground,
		Flying,
		Dark,
		Ghost,
		Bug,
		Fire,
		Water,
		Grass,
		Electric,
		Psychic,
		Steel,
		Dragon,
		Poison
	}
	
	public enum StatusEffect
	{
		None,
		Fainted,
		Asleep,
		Paralyzed,
		Poisoned,
		Confused,
		Burned,
		Frozen
	}
	
	public enum MoveProjectileType
	{
		Melee,
		Dash,
		Ranged,
		RangedSeeking,
		MeleeSeeking
	}
	
	public Stats pokedex(Stats pokemon,int index,bool yourself = true)
	{
		switch(index)
		{
			case 1:
				pokemon.Name = "Bisasam";
				pokemon.type1 = Type.Grass;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 3:
				pokemon.Name = "Bisaflor";
				pokemon.type1 = Type.Grass;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 4:
				pokemon.Name = "Glumanda";
				pokemon.type1 = Type.Fire;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 6:
				pokemon.Name = "Glurak";
				pokemon.type1 = Type.Fire;
				pokemon.type2 = Type.Flying;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-11 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 7:
				pokemon.Name = "Schiggy";
				pokemon.type1 = Type.Water;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 9:
				pokemon.Name = "Turtok";
				pokemon.type1 = Type.Water;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 10:
				pokemon.Name = "Raupy";
				pokemon.type1 = Type.Bug;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 11:
				pokemon.Name = "Safkon";
				pokemon.type1 = Type.Bug;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 12:
				pokemon.Name = "Smettbo";
				pokemon.type1 = Type.Bug;
				pokemon.type2 = Type.Flying;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 13:
				pokemon.Name = "Hornliu";
				pokemon.type1 = Type.Bug;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 14:
				pokemon.Name = "Kokuna";
				pokemon.type1 = Type.Bug;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 17:
				pokemon.Name = "Tauboga";
				pokemon.type1 = Type.Normal;
				pokemon.type2 = Type.Flying;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 21:
				pokemon.Name = "Habitak";
				pokemon.type1 = Type.Normal;
				pokemon.type2 = Type.Flying;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 25:
				pokemon.Name = "Pikachu";
				pokemon.type1 = Type.Electric;
				pokemon.dashSpeed = 160;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 20;
				pokemon.height = 3.3f;
				pokemon.learnableMoves[1] = 2;
				pokemon.learnableMoves[2] = 3;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-4 * xAxisModifier,pokemon.height * 1.5f,-6);
				}
				break;
			case 26:
				pokemon.Name = "Raichu";
				pokemon.type1 = Type.Electric;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 37:
				pokemon.Name = "Vulpix";
				pokemon.type1 = Type.Fire;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 38:
				pokemon.Name = "Vulnona";
				pokemon.type1 = Type.Fire;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 41:
				pokemon.Name = "Zubat";
				pokemon.type1 = Type.Poison;
				pokemon.type2 = Type.Flying;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 92:
				pokemon.Name = "Nebulak";
				pokemon.type1 = Type.Ghost;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 93:
				pokemon.Name = "Alpollo";
				pokemon.type1 = Type.Ghost;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				pokemon.learnableMoves[1] = 3;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-11 * xAxisModifier,pokemon.height * 1.5f,-14);
				}
				break;
			case 94:
				pokemon.Name = "Gengar";
				pokemon.type1 = Type.Ghost;
				pokemon.type2 = Type.Poison;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 12;
				pokemon.learnableMoves[1] = 3;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-12 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 149:
				pokemon.Name = "Dragoran";
				pokemon.type1 = Type.Dragon;
				pokemon.type2 = Type.Flying;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-11);
				}
				break;
			case 151:
				pokemon.Name = "Mew";
				pokemon.type1 = Type.Psychic;
				pokemon.dashSpeed = 200;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 20;
				pokemon.height = 2.3f;
				pokemon.learnableMoves[1] = 3;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-4 * xAxisModifier,pokemon.height * 1.5f + 7,-6);
				}
				break;
			case 212:
				pokemon.Name = "Scherox";
				pokemon.type1 = Type.Bug;
				pokemon.type2 = Type.Steel;
				pokemon.dashSpeed = 330;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 30;
				pokemon.height = 11;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 248:
				pokemon.Name = "Despotar";
				pokemon.type1 = Type.Rock;
				pokemon.type2 = Type.Dark;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				pokemon.learnableMoves[1] = 3;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-11);
				}
				break;
			case 257:
				pokemon.Name = "Lohgock";
				pokemon.type1 = Type.Fire;
				pokemon.type2 = Type.Fighting;
				pokemon.dashSpeed = 320;
				pokemon.dashDuration = 0.5f;
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
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 50;
				pokemon.height = 25;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-35 * xAxisModifier,pokemon.height * 1.5f,-40);
				}
				break;
			case 376:
				pokemon.Name = "Metagross";
				pokemon.type1 = Type.Steel;
				pokemon.type2 = Type.Psychic;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-12 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 383:
				pokemon.Name = "Groudon";
				pokemon.type1 = Type.Ground;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
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
				pokemon.type2 = Type.Flying;
				pokemon.dashSpeed = 400;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 50;
				pokemon.height = 5;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-11);
				}
				break;
			case 386:
				pokemon.Name = "Deoxys";
				pokemon.type1 = Type.Psychic;
				pokemon.dashSpeed = 400;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 14;
				pokemon.learnableMoves[1] = 3;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-12 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			case 491:
				pokemon.Name = "Darkrai";
				pokemon.type1 = Type.Dark;
				pokemon.dashSpeed = 300;
				pokemon.dashDuration = 0.5f;
				pokemon.walkSpeed = 40;
				pokemon.height = 15;
				pokemon.learnableMoves[1] = 3;
				if(yourself)
				{
					Camera.main.transform.position = new Vector3(-10 * xAxisModifier,pokemon.height * 1.5f,-10);
				}
				break;
			default:
				return null;
		}
		
		pokemon.index = index;
		if(model[index] != null)
		{
			pokemon.model = Instantiate(model[index],pokemon.transform.position,pokemon.transform.rotation) as GameObject;
			pokemon.model.transform.parent = pokemon.transform;
		}
		
		return pokemon;
	}
	
	
	public Move movedex(Move move,int index)
	{
		switch(index)
		{
			case 1:
				move.Name = "Standart Attack";
				move.damage = 20;
				move.projectileType = MoveProjectileType.Dash;
				move.range = 20;
				move.speed = 1000;
				move.cooldownTime = 2f;
				move.castingTime = 0.33f;
				break;
			case 2:
				move.Name = "Tackle";
				move.damage = 40;
				move.type1 = Type.Normal;
				move.projectileType = MoveProjectileType.Dash;
				move.range = 30;
				move.speed = 1000;
				move.cooldownTime = 3;
				move.castingTime = 0.5f;
				break;
			case 3:
				move.Name = "Spukball";
				move.damage = 80;
				move.type1 = Type.Ghost;
				move.projectileType = MoveProjectileType.RangedSeeking;
				move.range = 100;
				move.speed = 25;
				move.castingTime = 2f;
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
