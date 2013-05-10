using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {
	
	public Pokedex pokedex;
	public Pokemon myPokemon;
	public Pokemon opponent;
	
	public GameObject opponent_prefab;
	
	public int myPokemonIndex;
	public int enemyPokemonIndex;
	
	void Start ()
	{
		loadBattleSetup();
		myPokemon.setStats(myPokemonIndex,true);
		//myPokemon.stats = pokedex.pokedex(myPokemon.stats,myPokemonIndex);
		spawnEnemy(enemyPokemonIndex);
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
		int damage = move.damage + attacker.level - defender.level;					//provisorisch
		
		defender.HP -= damage;
		
		print(attacker.stats.Name + " dealt " + damage + " damage to " + defender.stats.Name + ", using " + move.Name);
		
		if(defender.HP <= 0)
			faint(attacker,defender);
	}
	
	void faint(Pokemon winner,Pokemon loser)
	{
		Camera.main.GetComponent<CameraRotation>().lockOnEnemy = false;
		loser.status = Pokedex.StatusEffect.Fainted;
		
		winner.exp += loser.level * 10;												//provisorisch
		
		print (loser.stats.Name + " fainted");
		print (winner.stats.Name + " gained " + loser.level * 10 + " Exp");
	}
	
	void spawnEnemy(int index)
	{
		GameObject enemy = Instantiate(opponent_prefab,new Vector3(0,0,50),Quaternion.Euler(new Vector3(0,180,0))) as GameObject;
		if(pokedex.pokedex(enemy.GetComponentInChildren<Stats>(),index,false) != null)
		{
			opponent = enemy.GetComponentInChildren<Pokemon>();
			opponent.setStats(index);
			//opponent.stats = pokedex.pokedex(enemy.GetComponentInChildren<Stats>(),index,false);
		}
		else
			Destroy(enemy);
	}
	
	
	
	void Update ()
	{
		if(opponent == null)
		{
			System.Random rand = new System.Random();
			spawnEnemy(rand.Next(1,10000));
		}
	}
}
