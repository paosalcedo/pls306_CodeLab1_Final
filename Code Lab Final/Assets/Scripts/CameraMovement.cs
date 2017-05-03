using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	[SerializeField]float speed;
//	[SerializeField]float rotationSpeed;
	[SerializeField]KeyCode forwardKey;
	[SerializeField]KeyCode backKey;
	[SerializeField]KeyCode rightKey;
	[SerializeField]KeyCode leftKey;
//	[SerializeField]KeyCode rotateClockwise;
//	[SerializeField]KeyCode rotateCounterClockwise;
	 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move(Vector3.up, forwardKey);
		Move(Vector3.down, backKey);
		Move(Vector3.left, rightKey);
		Move(Vector3.right, leftKey);
		
//		ShootRay();
	}

	void Move(Vector3 dir, KeyCode key){
		//if the key passed to this function was pressed
		if(Input.GetKey(key)){
			transform.position += dir * speed * Time.deltaTime;
		}
	}
}
