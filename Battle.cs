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
	
	float determineEffectiveness(Move move,Pokemon victim)
	{
		return 1;													//provisorisch
	}
	
	float determineSTAB(Move move,Pokemon attacker)
	{
		return 1;													//provisorisch
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
		
		float damage = (((2f * attacker.level + 10f)/250f) * (attacker.attack/defender.defense) * move.damage + 2f) * additionalEffects;
		
		defender.HP -= (int)damage;
		
		print(attacker.stats.Name + " dealt " + (int)damage + " damage to " + defender.stats.Name + ", using " + move.Name);
		
		if(defender.HP <= 0)
			faint(attacker,defender);
	}
	
	void faint(Pokemon winner,Pokemon loser)
	{
		Camera.main.GetComponent<CameraRotation>().lockOnEnemy = false;
		loser.status = Pokedex.StatusEffect.Fainted;
		
		float gainedEXP = (loser.stats.EXPBaseValue * loser.level)/7;
		winner.exp += (int)gainedEXP;
		
		print (loser.stats.Name + " fainted");
		print (winner.stats.Name + " gained " + (int)gainedEXP + " Exp");
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
