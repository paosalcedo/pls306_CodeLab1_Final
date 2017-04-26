using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	[SerializeField]float speed;
	[SerializeField]float rotationSpeed;
	[SerializeField]KeyCode forwardKey;
	[SerializeField]KeyCode backKey;
	[SerializeField]KeyCode rotateClockwise;
	[SerializeField]KeyCode rotateCounterClockwise;
	
	Vector3 newVec;
	Vector3 newDir;
	[SerializeField]float raycastRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move(transform.right, forwardKey);
//		Move(-transform.right, backKey);
		RotatePlayer(1, rotateClockwise);
		RotatePlayer(-1, rotateCounterClockwise);

		ShootRay();
	}

	void Move(Vector3 dir, KeyCode key){
		//if the key passed to this function was pressed
		if(Input.GetKey(key)){
			transform.position += dir * speed * Time.deltaTime;
		}
	}

	void RotatePlayer(float rotDir, KeyCode key){
		if(Input.GetKey(key)){
			transform.Rotate(Vector3.forward * rotDir * rotationSpeed * Time.deltaTime);
		}
	}

	void ShootRay ()
	{
		Ray ray = new Ray (transform.position, transform.right);
		Debug.DrawRay (ray.origin, ray.direction * raycastRange, Color.red);
		
		RaycastHit rayHit = new RaycastHit ();

		if (Physics.Raycast (ray, out rayHit, raycastRange)) {
//			Debug.DrawRay (rayHit.point, rayHit.normal*raycastRange, Color.blue);
			Vector3 reflection = Vector3.Reflect(ray.direction, rayHit.normal);
 			Debug.DrawRay(rayHit.point, reflection * raycastRange, Color.blue);
		}
	}

}
