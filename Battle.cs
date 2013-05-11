using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {
	
	public Pokedex pokedex;
	public Pokemon myPokemon;
	public Pokemon opponent;
	
	public int myPokemonIndex;
	public int enemyPokemonIndex;
	
	public int castIndicator;
	
	public GameObject opponent_prefab;
	
	void Start ()
	{
		loadBattleSetup();
		myPokemon.setStats(myPokemonIndex,true);
		spawnEnemy(enemyPokemonIndex);
	}
	
	void OnGUI()
	{
		float indicationDuration = 1.5f;
		
		if(castIndicator != -1)
		{
			Move move;
			if(castIndicator < 5)
				move = myPokemon.move[castIndicator];
			else
				move = opponent.move[castIndicator%5];
			
			if(move.timeScinceUse < indicationDuration)
					GUI.Box(new Rect(Screen.width * 0.4f,25,Screen.width / 5,25),move.Name);
			else
				castIndicator = -1;
		}
	}
	
	public void setCastIndicator(Move move)
	{
		for(int i = 0; i < 10; i++)
		{
			if(i < 5)
			{
				if(myPokemon.move[i] == move)
				{
					castIndicator = i;
					break;
				}
			}
			if(i >= 5)
			{
				if(opponent.move[i%5] == move)
				{
					castIndicator = i;
					break;
				}
			}
		}
	}
	
	void loadBattleSetup()
	{
		if(GameObject.Find("Starter") != null)
		{
			myPokemonIndex = GameObject.Find("Starter").GetComponent<StarterMenu>().starterIndex;
			enemyPokemonIndex = GameObject.Find("Starter").GetComponent<StarterMenu>().enemyIndex;
			Destroy(GameObject.Find("Starter"));
		}
	}
	
	float checkWeakness(Pokedex.Type Type1,Pokedex.Type Type2)
	{
		if(Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Bug
		|| Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Ice
		|| Type1 == Pokedex.Type.Water && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Water && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Water && Type2 == Pokedex.Type.Ground
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Ground
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Water
		|| Type1 == Pokedex.Type.Electric && Type2 == Pokedex.Type.Water
		|| Type1 == Pokedex.Type.Electric && Type2 == Pokedex.Type.Flying
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Ground
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Flying
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Dragon
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Normal
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Ice
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Dark
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Poison && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Electric
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Poison
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Flying && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Flying && Type2 == Pokedex.Type.Fighting
		|| Type1 == Pokedex.Type.Flying && Type2 == Pokedex.Type.Bug
		|| Type1 == Pokedex.Type.Psychic && Type2 == Pokedex.Type.Fighting
		|| Type1 == Pokedex.Type.Psychic && Type2 == Pokedex.Type.Poison
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Psychic
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Dark
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Ice
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Fighting
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Bug
		|| Type1 == Pokedex.Type.Ghost && Type2 == Pokedex.Type.Psychic
		|| Type1 == Pokedex.Type.Ghost && Type2 == Pokedex.Type.Ghost
		|| Type1 == Pokedex.Type.Dragon && Type2 == Pokedex.Type.Dragon
		|| Type1 == Pokedex.Type.Dark && Type2 == Pokedex.Type.Psychic
		|| Type1 == Pokedex.Type.Dark && Type2 == Pokedex.Type.Ghost
		|| Type1 == Pokedex.Type.Steel && Type2 == Pokedex.Type.Ice
		|| Type1 == Pokedex.Type.Steel && Type2 == Pokedex.Type.Rock)
			return 2;
		else if(Type1 == Pokedex.Type.Normal && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Normal && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Water
		|| Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Fire && Type2 == Pokedex.Type.Dragon
		|| Type1 == Pokedex.Type.Water && Type2 == Pokedex.Type.Water
		|| Type1 == Pokedex.Type.Water && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Water && Type2 == Pokedex.Type.Dragon
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Bug
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Poison
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Flying
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Dragon
		|| Type1 == Pokedex.Type.Grass && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Electric && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Electric && Type2 == Pokedex.Type.Electric
		|| Type1 == Pokedex.Type.Electric && Type2 == Pokedex.Type.Dragon
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Water
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Ice
		|| Type1 == Pokedex.Type.Ice && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Poison
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Flying
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Psychic
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Bug
		|| Type1 == Pokedex.Type.Poison && Type2 == Pokedex.Type.Poison
		|| Type1 == Pokedex.Type.Poison && Type2 == Pokedex.Type.Ground
		|| Type1 == Pokedex.Type.Poison && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Poison && Type2 == Pokedex.Type.Ghost
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Grass
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Bug
		|| Type1 == Pokedex.Type.Flying && Type2 == Pokedex.Type.Electric
		|| Type1 == Pokedex.Type.Flying && Type2 == Pokedex.Type.Rock
		|| Type1 == Pokedex.Type.Flying && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Psychic && Type2 == Pokedex.Type.Psychic
		|| Type1 == Pokedex.Type.Psychic && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Fighting
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Poison
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Flying
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Ghost
		|| Type1 == Pokedex.Type.Bug && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Ice
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Flying
		|| Type1 == Pokedex.Type.Rock && Type2 == Pokedex.Type.Bug
		|| Type1 == Pokedex.Type.Ghost && Type2 == Pokedex.Type.Dark
		|| Type1 == Pokedex.Type.Ghost && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Dragon && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Dark && Type2 == Pokedex.Type.Fighting
		|| Type1 == Pokedex.Type.Dark && Type2 == Pokedex.Type.Dark
		|| Type1 == Pokedex.Type.Dark && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Steel && Type2 == Pokedex.Type.Fire
		|| Type1 == Pokedex.Type.Steel && Type2 == Pokedex.Type.Water
		|| Type1 == Pokedex.Type.Steel && Type2 == Pokedex.Type.Electric
		|| Type1 == Pokedex.Type.Steel && Type2 == Pokedex.Type.Steel)
			return 0.5f;
		else if(Type1 == Pokedex.Type.Normal && Type2 == Pokedex.Type.Ghost
		|| Type1 == Pokedex.Type.Electric && Type2 == Pokedex.Type.Ground
		|| Type1 == Pokedex.Type.Fighting && Type2 == Pokedex.Type.Ghost
		|| Type1 == Pokedex.Type.Poison && Type2 == Pokedex.Type.Steel
		|| Type1 == Pokedex.Type.Ground && Type2 == Pokedex.Type.Flying
		|| Type1 == Pokedex.Type.Psychic && Type2 == Pokedex.Type.Dark
		|| Type1 == Pokedex.Type.Ghost && Type2 == Pokedex.Type.Normal)
			return 0;
		else
			return 1;
	}
	
	
	float determineEffectiveness(Move move,Pokemon victim)
	{
		float effectiveness = checkWeakness(move.type,victim.stats.type1) * checkWeakness(move.type,victim.stats.type2);
		//print(effectiveness);
		return effectiveness;
	}
	
	float determineSTAB(Move move,Pokemon attacker)
	{
		if(move.type == attacker.stats.type1 || move.type == attacker.stats.type2)
		{
			return 1.5f;
		}
		else
			return 1;
	}
	
	public void attack(Pokemon attacker,Move move)
	{
		Pokemon defender;
		
		if(attacker == myPokemon)
		{
			defender = opponent;
		}
		else
		{
			defender = myPokemon;
		}
		
		move.attack(defender);
	}
	
	public void hit(Pokemon attacker,Pokemon defender,Move move)
	{
		float additionalEffects = determineEffectiveness(move,defender) * determineSTAB(move,attacker);
		
		float damage = 0;
		if(move.category == Pokedex.MoveCategory.Physical)
		{
			damage = (((2f * attacker.level + 10f)/250f) * (attacker.attack/defender.defense) * move.damage + 2f);
		}
		else if(move.category == Pokedex.MoveCategory.Special)
		{
			damage = (((2f * attacker.level + 10f)/250f) * (attacker.specialAttack/defender.specialDefense) * move.damage + 2f);
		}
		damage *= additionalEffects;
		
		defender.HP -= (int)damage;
		
		//print(attacker.stats.Name + " dealt " + (int)damage + " damage to " + defender.stats.Name + ", using " + move.Name);
		
		if(defender.HP <= 0)
			faint(attacker,defender);
	}
	
	void faint(Pokemon winner,Pokemon loser)
	{
		Camera.main.GetComponent<CameraRotation>().lockOnEnemy = false;
		loser.status = Pokedex.StatusEffect.Fainted;
		
		float gainedEXP = (loser.stats.EXPBaseValue * loser.level)/7;
		winner.exp += (int)gainedEXP;
		
		//print (loser.stats.Name + " fainted");
		//print (winner.stats.Name + " gained " + (int)gainedEXP + " Exp");
	}
	
	void spawnEnemy(int index)
	{
		GameObject enemy = Instantiate(opponent_prefab,new Vector3(0,0,50),Quaternion.Euler(new Vector3(0,180,0))) as GameObject;
		if(pokedex.pokedex(enemy.GetComponentInChildren<Stats>(),index,false) != null)
		{
			opponent = enemy.GetComponentInChildren<Pokemon>();
			opponent.setStats(index);
		}
		else
			Destroy(enemy);
	}
	
	
	void Update ()
	{
		if(opponent == null)
		{
			System.Random rand = new System.Random();
			spawnEnemy(rand.Next(1,1000));
		}
	}
}
