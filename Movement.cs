using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public Vector3 speed;
	public Pokemon pokemon;
	
	float buttonCooler;
	public string lastKey;
	
	string dashDirection;
	public float dashTime;
	public Vector3 dashRotation;
	
	void Start ()
	{
	}
	
	bool determineDoubleTap()
	{
		if(Input.anyKeyDown)
		{
			if(lastKey != "" && buttonCooler > 0)
			{
				if(Input.GetKeyDown(lastKey))
				{
					return true;
				}
			}
			if(Input.GetKeyDown("w"))
				lastKey = "w";
			else if(Input.GetKeyDown("a"))
				lastKey = "a";
			else if(Input.GetKeyDown("s"))
				lastKey = "s";
			else if(Input.GetKeyDown("d"))
				lastKey = "d";
			else
				lastKey = "";
			
			buttonCooler = 0.3f;
		}
		
		if(buttonCooler > 0)
			buttonCooler -= Time.deltaTime;
		
		return false;
	}
	
	void walk()
	{
		if(Input.GetKey("w"))
		{
			speed += Vector3.forward * Time.deltaTime * pokemon.walkSpeed;
		}
		if(Input.GetKey("a"))
		{
			speed += Vector3.left * Time.deltaTime * pokemon.walkSpeed;
		}
		if(Input.GetKey("s"))
		{
			speed += Vector3.back * Time.deltaTime * pokemon.walkSpeed;
		}
		if(Input.GetKey("d"))
		{
			speed += Vector3.right * Time.deltaTime * pokemon.walkSpeed;
		}
	}
	
	void dash()
	{
		dashTime -= Time.deltaTime;
		if(dashDirection == "w")
		{
			speed += Vector3.forward * dashTime * pokemon.dashSpeed;
		}
		if(dashDirection == "a")
		{
			speed += Vector3.left * dashTime * pokemon.dashSpeed;
		}
		if(dashDirection == "s")
		{
			speed += Vector3.back * dashTime * pokemon.dashSpeed;
		}
		if(dashDirection == "d")
		{
			speed += Vector3.right * dashTime * pokemon.dashSpeed;
		}
		
	}
	
	void move()
	{
		if(dashTime > 0)
		{
			Vector3 originalRotation = transform.eulerAngles;
			transform.eulerAngles = dashRotation;
			transform.Translate(speed);
			transform.eulerAngles = originalRotation;
		}
		else
			transform.Translate(speed);
			
		speed = Vector3.zero;
	}
	
	
	void Update ()
	{
		if(determineDoubleTap() && dashTime <= 0)
		{
			dashDirection = lastKey;
			dashRotation = transform.eulerAngles;
			dashTime = pokemon.dashDuration;
		}
		if(dashTime > 0)
			dash ();
		walk();
		move();
	}
}
