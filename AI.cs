using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public Pokemon pokemon;
	public Pokemon opponent;
	
	public bool AIActive;
	
	void Start ()
	{
		opponent = Camera.main.GetComponent<Battle>().myPokemon;
	}
	
	void faint()
	{
		if(pokemon.model.transform.position.y >= 0)
		{
			pokemon.movement.triggerMovement(Vector3.down,pokemon.height * 1.5f,1);
		}
		
		else if(pokemon.stats.status == Pokedex.StatusEffect.Fainted && pokemon.transform.parent.position.y < 0 && !pokemon.movement.moving())
		{
			Destroy(pokemon.transform.parent.gameObject);
		}
	}
	
	void pathfinding()
	{
		pokemon.movement.triggerChase(opponent.transform,5,1);
	}
	
	void attack()
	{
		System.Random rand = new System.Random();
		int randomMove = rand.Next(5);
		do
		{
			randomMove = rand.Next(5);
		} while(pokemon.stats.move[randomMove] == null);
		
		if(Vector3.Distance(transform.position,opponent.transform.position) < pokemon.stats.move[randomMove].range)
		{
			pokemon.stats.move[randomMove].cast();
		}
	}
	
	void dodge()
	{
		GameObject projectile = GameObject.Find("Projectile");
		if(projectile.GetComponent<Projectile>().target == pokemon)
		{
			Vector3 direction = projectile.transform.position - transform.position;
			direction = Vector3.Cross(direction,Vector3.up);
			pokemon.movement.triggerDodge(direction,pokemon.dashSpeed,pokemon.dashDuration,true);
		}
	}
	
	void deactivateAI()
	{
		if(Input.GetKeyDown("q") && AIActive)
			AIActive = false;
		else if(Input.GetKeyDown("q") && !AIActive)
			AIActive = true;
	}
	
	void Update ()
	{
		if(pokemon.stats.status == Pokedex.StatusEffect.Fainted)
		{
			faint();
		}
		if(pokemon.stats.status != Pokedex.StatusEffect.Fainted && AIActive)
		{
			pathfinding();
			attack();
			if(GameObject.Find("Projectile") != null)
				dodge();
		}
		deactivateAI();
	}
}
