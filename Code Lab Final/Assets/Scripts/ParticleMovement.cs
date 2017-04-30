using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {
	public float raycastRange = 5f;
	public float speed = 10f;

	Vector3 dir;
	
	// Use this for initialization
	void Start () {
 	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move ()
	{
		Ray ray = new Ray (transform.position, dir);
		Debug.DrawRay (ray.origin, ray.direction * raycastRange, Color.red);
		
		RaycastHit rayHit = new RaycastHit ();
		
		transform.position += dir * speed * Time.deltaTime;

		if (Physics.Raycast (ray, out rayHit, raycastRange)) {
//			Debug.DrawRay (rayHit.point, rayHit.normal*raycastRange, Color.blue);
			Vector3 reflection = Vector3.Reflect (ray.direction, rayHit.normal);
			Debug.DrawRay (rayHit.point, reflection * raycastRange, Color.blue);
			if (
				Vector3.Distance (transform.position, rayHit.point) < 0.25f) {
				dir = reflection;
			}

		}
		else {
				dir = transform.right;
		}
		//change the movement vector to be equal to the reflected ray.
	

	}
}
