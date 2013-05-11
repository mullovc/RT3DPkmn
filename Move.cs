using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	Battle battle;
	public Pokemon pokemon;
	public Projectile projectile_prefab;
	public Projectile projectile;
	
	public int index;
	public string Name;
	public int damage;
	public int accuracy;
	
	public float range;
	public float speed;
	public float duration;
	
	public float cooldownTime;
	public float castingTime;
	public float timeScinceUse;
	bool casting;
	
	public bool projectileIsActive;
	public float projectileTimeLeft;
	
	public Pokedex.Type type1;
	public Pokedex.Type type2;
	public Pokedex.StatusEffect statusEffect;
	public Pokedex.MoveProjectileType projectileType;
	
	public GameObject model;
	
	void Start ()
	{
		timeScinceUse = cooldownTime + 1.5f;
		battle = Camera.main.GetComponent<Battle>();
	}
	
	public void cast()
	{
		if(timeScinceUse > (cooldownTime + castingTime) && !projectileIsActive)
		{
			pokemon.movement.disable(castingTime);
			timeScinceUse = 0;
			casting = true;
			battle.setCastIndicator(this);
		}
	}
	
	public void attack(Pokemon target)
	{
		projectile = Instantiate(projectile_prefab,transform.position,pokemon.transform.rotation) as Projectile;
		projectile.target = target;
		projectile.attacker = pokemon;
		projectile.model = model;
		projectile.name = "Projectile";
		
		Vector3 direction = (target.transform.position - transform.position).normalized;
			
		if(projectileType == Pokedex.MoveProjectileType.Dash)
		{
			pokemon.transform.parent.parent = projectile.transform;
			projectile.movement.triggerDash(direction,speed,Mathf.Sqrt(2 * range / speed));
			projectileTimeLeft = Mathf.Sqrt(2 * range / speed);
			pokemon.movement.disable(projectileTimeLeft);
		}
		else if(projectileType == Pokedex.MoveProjectileType.Ranged)
		{
			projectile.movement.triggerMovement(direction,speed,range/speed);
			projectileTimeLeft = range/speed;
		}
		else if(projectileType == Pokedex.MoveProjectileType.RangedSeeking)
		{
			projectile.movement.triggerChase(target.transform,speed,range/speed);
			projectileTimeLeft = range/speed;
		}
		projectileIsActive = true;
	}
	
	void Update ()
	{
		if(projectileIsActive)
		{
			if(projectile.checkCollision())
			{
				if(pokemon.transform.parent.parent == projectile.transform)
				{
					pokemon.transform.parent.parent = null;
				}
				Destroy(projectile.gameObject);
				battle.hit(pokemon,projectile.target,this);
				projectileIsActive = false;
			}
			else if(projectileTimeLeft <= 0)
			{
				if(pokemon.transform.parent.parent == projectile.transform)
				{
					pokemon.transform.parent.parent = null;
				}
				Destroy(projectile.gameObject);
				projectileIsActive = false;
			}
			projectileTimeLeft -= Time.deltaTime;
		}
		timeScinceUse += Time.deltaTime;
		
		if(casting && timeScinceUse > castingTime)
		{
			casting = false;
			battle.attack(pokemon,this);
		}
	}
}
