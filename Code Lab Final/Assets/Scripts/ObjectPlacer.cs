using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour {
	
	protected int blockNum;
 	[SerializeField]KeyCode block01;
	[SerializeField]KeyCode block02;
	[SerializeField]KeyCode block03;
	[SerializeField]KeyCode block04;
	[SerializeField]KeyCode block05;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		BlockSelect(1, block01);
		BlockSelect(2, block02);
		BlockSelect(3, block03);
		BlockSelect(4, block04);

 		if (Input.GetMouseButtonDown (0)) { //On mouse button down
			PlaceObject(blockNum);
		}
	}

	public virtual void PlaceObject (int num)
	{
		num = blockNum;
		if (num == 1) {
			RaycastHit rayHit; //create a RaycastHit object	
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit, Camera.main.farClipPlane)) {
				GameObject cube = Instantiate (Resources.Load ("Prefabs/Cube") as GameObject);
				cube.transform.position = rayHit.point;
				Debug.Log (rayHit.transform.name);
			} else {
				Debug.Log ("hit nothing!");
			}
		}
  	}

	void BlockSelect (int num, KeyCode key)
	{
		if (Input.GetKeyDown (key)) {
			blockNum = num;
		}
	}
}

