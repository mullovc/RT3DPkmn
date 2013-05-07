using UnityEngine;
using System.Collections;

public class Pokemon : MonoBehaviour {
	
	public Stats stats;
	
	public int index;
	public string Name;
	public float walkSpeed;
	public float dashSpeed;
	public float dashDuration;
	public float height;
	
	public int[] learnableMoves = new int[100];
	public int[] evolution = new int[100];
	
	public Pokedex.Type type1;
	public Pokedex.Type type2;
	
	public GameObject model;
	
	void Start ()
	{
		
	}
	
	
	void Update ()
	{
		
	}
}
