using UnityEngine;
using System.Collections;

public class Pokemon : MonoBehaviour {
	
	public Stats stats;
	public Movement movement;
	public Pokedex pokedex;
	
	public int level;
	public float HP;
	public float exp;
	
	public int expToNextLevel;
	
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
	
	void levelUp()
	{
		level++;
		if(expToNextLevel != 0)
			exp = exp % expToNextLevel;
		
		expToNextLevel = (int)Mathf.Pow(level + 1,3);
		
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
