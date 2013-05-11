using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	
	public int index;
	public string Name;
	public float walkSpeed;
	public float dashSpeed;
	public float dashDuration;
	public float height;
	
	public float HPBaseValue;
	public float attackBaseValue;
	public float specialAttackBaseValue;
	public float defenseBaseValue;
	public float specialDefenseBaseValue;
	public float initiativeBaseValue;
	public float EXPBaseValue;
	
	public int[] learnableMoves = new int[100];
	public int[] evolution = new int[100];
	
	public Pokedex.Type type1;
	public Pokedex.Type type2;
	public Pokedex.LevelingSpeed levelingSpeed;
	
	public GameObject model;
	
	void Start ()
	{
		
	}
	
	
	void Update ()
	{
		
	}
}
