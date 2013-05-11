using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public GameObject model;
	
	public Pokemon attacker;
	public Pokemon target;
	public Movement movement;
	
	void Start ()
	{
		if(model != null)
		{
			model = Instantiate(model,transform.position,Quaternion.identity) as GameObject;
			model.transform.parent = transform;
		}
	}
	
	public bool checkCollision()
	{
		Ray ray = new Ray(transform.position,target.transform.position - transform.position);
		if(Physics.Raycast(ray,2))
			return true;
		else
			return false;
	}
	
	
	void Update ()
	{
		
	}
}
