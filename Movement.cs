using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public Vector3 speed;
	public Pokemon pokemon;
	
	Vector3 movementDirection;
	float movementTime;
	
	bool dashAtEnemy;
	Vector3 dashDirection;
	float dashTime;
	Vector3 dashRotation;
	
	public Transform chaseTarget;
	float chaseTime;
	float chaseSpeed;
	
	void Start ()
	{
		
	}
	
	void dash()
	{
		speed += dashDirection * dashTime * Time.deltaTime;
		dashTime -= Time.deltaTime;
		//speed += dashDirection * (-Mathf.Pow(((dashTime - pokemon.dashDuration)/pokemon.dashDuration),12) + pokemon.dashSpeed);
	}
	
	public void triggerDash(Vector3 direction,float speed,float duration,bool atEnemy = true)
	{
		if(dashTime <= 0)
		{
			dashAtEnemy = atEnemy;
			dashDirection = direction * speed;
			dashTime = duration;
			dashRotation = transform.eulerAngles;
		}
	}
	
	void movement()
	{
		speed += movementDirection * Time.deltaTime;
		movementTime -= Time.deltaTime;
	}
	
	public void triggerMovement(Vector3 direction,float speed,float duration)
	{
		movementDirection = direction * speed;
		movementTime = duration;
	}
	
	void chase()
	{
		Vector3 direction = chaseTarget.position - transform.position;
		direction /= Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);
		speed += direction * chaseSpeed * Time.deltaTime;
		chaseTime -= Time.deltaTime;
	}
	
	public void triggerChase(Transform target,float speed,float duration)
	{
		chaseTarget = target;
		chaseSpeed = speed;
		chaseTime = duration;
	}
	
	
	void translation()
	{
		if(dashTime > 0 && !dashAtEnemy)
		{
			Vector3 originalRotation = transform.eulerAngles;
			transform.eulerAngles = dashRotation;
			transform.Translate(speed);
			transform.eulerAngles = originalRotation;
		}
		else if(dashTime > 0 && dashAtEnemy || chaseTime > 0)
		{
			transform.Translate(speed,Space.World);
		}
		else
		{
			transform.Translate(speed);
		}
		
		speed = Vector3.zero;
	}
	
	
	void Update ()
	{
		if(dashTime > 0)
			dash ();
		if(movementTime > 0)
			movement();
		if(chaseTime > 0)
			chase();
		
		translation();
	}
}
