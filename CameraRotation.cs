using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	
	public Movement movement;
	Transform player;
	public bool lockOnEnemy;
	Transform enemy;
	public Settings settings;
	
	void Start ()
	{
		player = transform.parent;
		enemy = Camera.main.GetComponent<Battle>().opponent.transform;
		lockOnEnemy = true;
	}
	
	void lockOn()
	{
		if(Input.GetKeyDown("tab"))
		{
			if(lockOnEnemy)
			{
				lockOnEnemy = false;
			}
			else if(!lockOnEnemy)
			{
				lockOnEnemy = true;
			}
		}
	}
	
	void setCameraPosition()
	{
		if(Input.GetKey("left"))
			player.eulerAngles += new Vector3(0,-settings.cameraRotationSpeed,0);
		if(Input.GetKey("right"))
			player.eulerAngles += new Vector3(0,settings.cameraRotationSpeed,0);
		if(Input.GetKey("up"))
		{
			Vector3 a = player.position - transform.position;
			transform.position += a * 0.02f;
		}
		if(Input.GetKey("down"))
		{
			Vector3 a = player.position - transform.position;
			transform.position -= a * 0.02f;
		}
	}
	
	void setCameraPosition(Transform looker,Transform lookedAt)
	{		
		Vector3 a = lookedAt.position - looker.position;
		Vector3 pos = looker.position - (a / (Mathf.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z))) * 5;
		transform.position = new Vector3(pos.x,pos.y + 1.5f,pos.z);
	}
	
	
	void setCameraRotation(Vector3 looker, Vector3 lookedAt)
	{
		float alpha = calcDirection(looker,lookedAt);
		float beta = calcTendency(lookedAt);
		player.eulerAngles = new Vector3(0,alpha,0);
		transform.eulerAngles = new Vector3(beta,alpha,0);
	}
	
	float calcTendency(Vector3 a)
	{
		Vector3 b = a - transform.position;
		return -Mathf.Atan(b.y/Mathf.Sqrt(b.z * b.z + b.x * b.x)) * (180/Mathf.PI);
	}
	
	float calcDirection(Vector3 a,Vector3 b)
	{
		Vector3 c = b - a;
		float alpha = Mathf.Atan(c.x/c.z) * (180/Mathf.PI);
		if(c.z < 0)
			alpha -= 180;
		return alpha;
	}
	
	void Update ()
	{
		lockOn();
		
		if(lockOnEnemy)
		{
			setCameraRotation(player.position,enemy.position);
		}
		if(!lockOnEnemy)
		{
			setCameraPosition();
		}
	}
}
