using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	Battle battle;
	public Pokemon pokemon;
	public Movement movement;
	
	public int index;
	public string Name;
	public int damage;
	public int accuracy;
	
	public float range;
	public float speed;
	
	public Pokedex.Type type1;
	public Pokedex.Type type2;
	public Pokedex.StatusEffect statusEffect;
	public Pokedex.MoveProjectileType projectileType;
	
	public GameObject model;
	
	void Start ()
	{
		battle = Camera.main.GetComponent<Battle>();
		movement = pokemon.transform.parent.GetComponent<Movement>();
	}
	
	public void triggerAttack()
	{
		battle.attack(pokemon,this);
	}
	
	public void attack(Transform target)
	{
		Vector3 direction = target.position - transform.position;
		direction /= Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);
		
		if(projectileType == Pokedex.MoveProjectileType.Dash)
		{
			movement.triggerDash(direction,speed,Mathf.Sqrt(2 * range / speed));
		}
		else if(projectileType == Pokedex.MoveProjectileType.Ranged)
		{
			movement.triggerMovement(direction,speed,range/speed);
		}
		else if(projectileType == Pokedex.MoveProjectileType.RangedSeeking)
		{
			movement.triggerChase(target,speed,range/speed);
		}
	}
	
	void Update ()
	{
		
	}
}
