using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	Battle battle;
	public Pokemon pokemon;
	
	public int index;
	public string Name;
	public int damage;
	public int accuracy;
	
	public Pokedex.Type type1;
	public Pokedex.Type type2;
	
	public GameObject model;
	
	void Start ()
	{
		battle = Camera.main.GetComponent<Battle>();
	}
	
	public void attack()
	{
		battle.attack(pokemon,this);
	}
	
	void Update ()
	{
		
	}
}
