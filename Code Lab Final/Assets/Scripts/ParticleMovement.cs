using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {
	public float raycastRange = 5f;
	public float speed = 10f;
//	public float speedX = 10f;
//	public float speedY = 10f;

	Vector3 dir;
	
	// Use this for initialization
	void Start () {
		LevelLoader.playerIsAtGoal = false;
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

//		rayHit.point method
		if (Physics.Raycast (ray, out rayHit, raycastRange)) {
//			Debug.DrawRay (rayHit.point, rayHit.normal*raycastRange, Color.blue);
			Vector3 reflection = Vector3.Reflect (ray.direction, rayHit.normal);
			Debug.DrawRay (rayHit.point, reflection * raycastRange, Color.blue);
			if (
				Vector3.Distance (transform.position, rayHit.point) < 0.25f && rayHit.collider.tag != "Goal") {
				dir = reflection;
			}
			else if (rayHit.collider.tag == "Goal") {
				Debug.Log("player hit goal # " + LevelLoader.levelNum);
				LevelLoader.playerIsAtGoal = true;
			}

//			if (isColliding == true) {
//				dir = reflection;
//			}
	
		} else {
			dir = transform.right;
		}


	}

//	public bool isColliding;
//
//	void OnTriggerEnter (Collider coll)
//	{
//		if (coll.tag == "Wall") {
//			isColliding = true;
//			Debug.Log ("Hit wall!");
//		}
//	}
//	
//	void OnCollisionEnter (Collision coll)
//	{
//		if (coll.gameObject.tag == "Wall") {
//			isColliding = true;
//		}
//	}

	
}
