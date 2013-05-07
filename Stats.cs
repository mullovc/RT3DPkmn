using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	
	public Pokemon pokemon;
	public Pokedex pokedex;
	
	public int level;
	public int exp;
	public int HP;
	
	public int maxHP;
	public int expToNextLevel;
	
	public Move[] move = new Move[4];
	
	void Start ()
	{
		for(int i = 0; i < 4; i++)
		{
			move[i] = new GameObject().AddComponent<Move>();
			move[i].name = "Move" + i;
			move[i].transform.parent = transform;
			move[i].pokemon = pokemon;
		}
	}
	
	bool checkLevelUp()
	{
		if(exp >= expToNextLevel)
		{
			return true;
		}
		else
			return false;
	}
	
	void levelUp()
	{
		level++;
		if(expToNextLevel != 0)
			exp = exp % expToNextLevel;
		
		expToNextLevel = level * 10;		//provisorisch
		maxHP = level * 10;					//provisorisch
		HP = maxHP;
		
		if(pokemon.learnableMoves[level] != 0)
		{
			learnMove(pokemon.learnableMoves[level]);
		}
		if(pokemon.evolution[level] != 0)
		{
			evolve(pokemon.evolution[level]);
		}
	}
	
	void learnMove(int moveToLearn)
	{
		for(int i = 0; i < 4; i++)
		{
			if(move[i].index == 0)
			{
				move[i] = pokedex.movedex(move[i],moveToLearn);
				break;
			}
		}
	}
	
	void evolve(int evolveTo)
	{
		//...
	}
	
	
	void Update ()
	{
		if(checkLevelUp())
		{
			levelUp();
		}
	}
}
