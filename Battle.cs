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
		myPokemon = pokedex.pokedex(myPokemon,myPokemonIndex);
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
		int damage = move.damage + attacker.stats.level - defender.stats.level;		//provisorisch
		
		defender.stats.HP -= damage;
		
		print(attacker.Name + " dealt " + damage + " damage to " + defender.Name + ", using " + move.Name);
		
		if(defender.stats.HP <= 0)
			faint(attacker,defender);
	}
	
	void faint(Pokemon winner,Pokemon loser)
	{
		Camera.main.GetComponent<CameraRotation>().lockOnEnemy = false;
		loser.stats.status = Pokedex.StatusEffect.Fainted;
		
		winner.stats.exp += loser.stats.level * 10;									//provisorisch
		
		print (loser.Name + " fainted");
		print (winner.Name + " gained " + loser.stats.level * 10 + " Exp");
	}
	
	void spawnEnemy(int index)
	{
		GameObject enemy = Instantiate(opponent_prefab,new Vector3(0,0,50),Quaternion.Euler(new Vector3(0,180,0))) as GameObject;
		if(pokedex.pokedex(enemy.GetComponentInChildren<Pokemon>(),index,false) != null)
			opponent = pokedex.pokedex(enemy.GetComponentInChildren<Pokemon>(),index,false);
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
