using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	Vector3 speed;
	
	float disabledTime;
	
	Vector3 walkDirection;
	float walkTime;
	
	float dodgeCooldown = -0.75f;
	public float dodgeTime;
	Vector3 dodgeDirection;
	Vector3 dodgeRotation;
	bool dodgeSpaceWorld;
	
	Vector3 movementDirection;
	float movementTime;
	
	float dashTime;
	Vector3 dashDirection;
	
	Transform chaseTarget;
	float chaseTime;
	float chaseSpeed;
	
	void Start ()
	{
		//dodgeTime = dodgeCooldown;
	}
	
	public bool moving()
	{
		return (chaseTime > 0 || dashTime > 0 || movementTime > 0 || dodgeTime > 0 || walkTime > 0);
	}
	
	bool checkDisabled()
	{
		disabledTime -= Time.deltaTime;
		return disabledTime > 0;
	}
	
	public void disable(float duration)
	{
		disabledTime = duration;
	}
	
	public void enable()
	{
		disabledTime = 0;
	}
	
	
	void dash()
	{
		speed += dashDirection * dashTime * Time.deltaTime;
		dashTime -= Time.deltaTime;
	}
	
	public void triggerDash(Vector3 direction,float speed,float duration)
	{
		if(dashTime <= 0)
		{
			direction = direction.normalized;
			dashDirection = direction * speed;
			dashTime = duration;
		}
	}
	
	void dodge()
	{
		if(dodgeTime > 0)
			speed += dodgeDirection * dodgeTime * Time.deltaTime;
		dodgeTime -= Time.deltaTime;
	}
	
	public void triggerDodge(Vector3 direction,float speed,float duration,bool spaceWorld = false)
	{
		if(dodgeTime <= dodgeCooldown)
		{
			direction = direction.normalized;
			dodgeDirection = direction * speed;
			dodgeTime = duration;
			dodgeRotation = transform.eulerAngles;
			dodgeSpaceWorld = spaceWorld;
		}
	}
	
	void walk()
	{
		speed += walkDirection * Time.deltaTime;
		walkTime -= Time.deltaTime;
	}
	
	public void triggerWalk(Vector3 direction,float speed,float duration)
	{
		direction = direction.normalized;
		walkDirection = direction * speed;
		walkTime = duration;
	}
	
	void movement()
	{
		speed += movementDirection * Time.deltaTime;
		movementTime -= Time.deltaTime;
	}
	
	public void triggerMovement(Vector3 direction,float speed,float duration)
	{
		direction = direction.normalized;
		movementDirection = direction * speed;
		movementTime = duration;
	}
	
	void chase()
	{
		Vector3 direction = chaseTarget.position - transform.position;
		direction = direction.normalized;
		speed += direction * chaseSpeed * Time.deltaTime;
		transform.rotation = Quaternion.LookRotation(direction);
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
		if(dodgeTime > 0)
		{
			if(!dodgeSpaceWorld)
			{
				Vector3 originalRotation = transform.eulerAngles;
				transform.eulerAngles = dodgeRotation;
				transform.Translate(speed);
				transform.eulerAngles = originalRotation;
			}
			else if(dodgeSpaceWorld)
			{
				transform.Translate(speed,Space.World);
			}
		}
		else if(dashTime > 0 || chaseTime > 0 || movementTime > 0)
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
		if(!checkDisabled())
		{
			if(dashTime > 0)
				dash ();
			if(movementTime > 0)
				movement();
			if(chaseTime > 0)
				chase();
			if(dodgeTime > -1)
				dodge();
			if(walkTime > 0)
				walk();
		}
		
		translation();
	}
}
