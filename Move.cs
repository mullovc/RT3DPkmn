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
	
	public Pokedex.Type type;
	public Pokedex.MoveCategory category;
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
		else if(projectileType == Pokedex.MoveProjectileType.AttackerOrbit)
		{
			projectile.movement.triggerChase(target.transform,speed,range/speed);
			projectile.transform.parent = transform;
			projectileTimeLeft = 5;
			pokemon.movement.disable(projectileTimeLeft);
		}
		projectileIsActive = true;
	}
	
	void destroyProjectile(bool hit)
	{
		if(pokemon.transform.parent.parent == projectile.transform)
		{
			pokemon.transform.parent.parent = null;
		}
		Destroy(projectile.gameObject);
		projectileIsActive = false;
		pokemon.movement.enable();
		if(hit)
			battle.hit(pokemon,projectile.target,this);
	}
	
	void Update ()
	{
		if(projectileIsActive)
		{
			if(projectile.checkCollision())
				destroyProjectile(true);
			else if(projectileTimeLeft <= 0)
				destroyProjectile(false);
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
