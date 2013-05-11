using UnityEngine;
using System.Collections;

public class Pokemon : MonoBehaviour {
	
	public Stats stats;
	public Movement movement;
	public Pokedex pokedex;
	
	public int level;
	public float HP;
	public float exp;
	
	public float expToNextLevel;
	
	public float maxHP;
	public float attack;
	public float specialAttack;
	public float defense;
	public float specialDefense;
	public float initiative;
	
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
	
	public float getExpToNextLevel(float n)
	{
		float result = 0;
		
		if(stats.levelingSpeed == Pokedex.LevelingSpeed.Erratic)
		{
			if(n <= 50)
				result = Mathf.Pow(n,3)*((100 - n)/50);
			else if(n > 50 && n <= 68)
				result = Mathf.Pow(n,3)*((150 - n)/100);
			else if(n > 68 && n <= 98)
				result = Mathf.Pow(n,3)*((1911 - 10 * n)/1500);
			else if(n > 98 && n <= 100)
				result = Mathf.Pow(n,3)*((160 - n)/100);
		}
		else if(stats.levelingSpeed == Pokedex.LevelingSpeed.Fast)
		{
			result = (4 * Mathf.Pow(n,3))/5;
		}
		else if(stats.levelingSpeed == Pokedex.LevelingSpeed.MediumFast)
		{
			result = Mathf.Pow(n,3);
		}
		else if(stats.levelingSpeed == Pokedex.LevelingSpeed.MediumSlow)
		{
			result = (6/5) * Mathf.Pow(n,3) - 15 * n*n + 100 * n - 140;
		}
		else if(stats.levelingSpeed == Pokedex.LevelingSpeed.Slow)
		{
			result = (5/4) * Mathf.Pow(n,3);
		}
		else if(stats.levelingSpeed == Pokedex.LevelingSpeed.Fluctuating)
		{
			if(n <= 15)
				result = Mathf.Pow(n,3)*((((n+1)/3)+24)/50);
			else if(n > 15 && n <= 36)
				result = Mathf.Pow(n,3)*((n+14)/50);
			else if(n > 36 && n <= 100)
				result = Mathf.Pow(n,3)*(((n/2)+32)/50);
		}
		
		return result;
	}
	
	void levelUp()
	{
		level++;
		
		expToNextLevel = (int)getExpToNextLevel(level + 1f);
		
		maxHP = (int)((2f * stats.HPBaseValue + 100f) * (level/100f) + 10f);
		attack = (int)(2 * stats.attackBaseValue * (level / 100f) + 5f);
		specialAttack = (int)(2f * stats.specialAttackBaseValue * (level / 100f) + 5f);
		defense = (int)(2f * stats.defenseBaseValue * (level / 100f) + 5f);
		specialDefense = (int)(2f * stats.specialDefenseBaseValue * (level / 100f) + 5f);
		initiative = (int)(2f * stats.initiativeBaseValue * (level / 100f) + 5f);
		
		HP = (int)maxHP;
		
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
		setStats(stats.evolution[level], true);
	}
	
	public void setStats(int index,bool mySelf = false)
	{
		stats = pokedex.pokedex(stats,index,mySelf);
	}
	
	
	void Update ()
	{
		if(exp >= expToNextLevel)
		{
			levelUp();
		}
	}
}
