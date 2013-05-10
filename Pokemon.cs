using UnityEngine;
using System.Collections;

public class Pokemon : MonoBehaviour {
	
	public Stats stats;
	public Movement movement;
	public Pokedex pokedex;
	
	public int level;
	public int exp;
	public int HP;
	
	public int maxHP;
	public int expToNextLevel;
	
	public Pokedex.StatusEffect status;
	
	public Move move_prefab;
	public Move[] move = new Move[5];
	
	void Start ()
	{
		for(int i = 0; i < 5; i++)
		{
			move[i] = Instantiate(move_prefab,transform.position,Quaternion.identity) as Move;
			move[i].name = "Move" + i;
			move[i].transform.parent = transform;
			move[i].pokemon = this;
		}
		learnMove(1);
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
		
		if(stats.learnableMoves[level] != 0)
		{
			learnMove(stats.learnableMoves[level]);
		}
		if(stats.evolution[level] != 0)
		{
			evolve(stats.evolution[level]);
		}
	}
	
	void learnMove(int moveToLearn)
	{
		for(int i = 0; i < 5; i++)
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
	
	public void setStats(int index,bool mySelf = false)
	{
		stats = pokedex.pokedex(stats,index,mySelf);
	}
	
	
	void Update ()
	{
		if(checkLevelUp())
		{
			levelUp();
		}
	}
}
