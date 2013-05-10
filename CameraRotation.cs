using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	
	Transform player;
	public bool lockOnEnemy;
	public Transform enemy;
	public Settings settings;
	
	void Start ()
	{
		player = transform.parent;
		lockOnEnemy = true;
	}
	
	public void lockOn()
	{
		if(Input.GetKeyDown("tab"))
		{
			if(lockOnEnemy)
			{
				lockOnEnemy = false;
			}
			else if(!lockOnEnemy && enemy != null)
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
		player.rotation = Quaternion.LookRotation(lookedAt - looker);
		transform.rotation = Quaternion.LookRotation(lookedAt - transform.position);
	}
	
	void Update ()
	{
		if(enemy == null && transform.GetComponent<Battle>().opponent != null)
		{
			enemy = transform.GetComponent<Battle>().opponent.transform;
		}
		
		lockOn();
		
		if(lockOnEnemy)
			setCameraRotation(player.position,enemy.position);
		if(!lockOnEnemy)
			setCameraPosition();
	}
}
