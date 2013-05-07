using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {
	
	public Pokedex pokedex;
	public Pokemon myPokemon;
	public Pokemon opponent;
	
	public int myPokemonIndex;
	public int enemyPokemonIndex;
	
	void Start ()
	{
		loadBattleSetup();
		myPokemon = pokedex.pokedex(myPokemon,myPokemonIndex);
		opponent = pokedex.pokedex(opponent,enemyPokemonIndex,false);
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
		
		move.attack(defender.transform);
		
		int damage = move.damage * attacker.stats.level / defender.stats.level;		//provisorisch
		
		defender.stats.HP -= damage;
		
		print(attacker.Name + " dealt " + damage + " damage to " + defender.Name + ", using " + move.Name);
	}
	
	void Update ()
	{
		
	}
}
