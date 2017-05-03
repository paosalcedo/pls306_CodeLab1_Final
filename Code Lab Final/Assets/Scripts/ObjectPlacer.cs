using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour {
	
	protected int blockNum;
 	[SerializeField]KeyCode block01;
	[SerializeField]KeyCode block02;
//	[SerializeField]KeyCode block03;
//	[SerializeField]KeyCode block04;
//	[SerializeField]KeyCode block05;
	
	GameObject cursorCube;

	// Use this for initialization
	void Start () {
		cursorCube = Instantiate (Resources.Load ("Prefabs/CursorCube") as GameObject);
 	}
	
	// Update is called once per frame
	void Update () {
		ObjectSelect(1, block01);
		ObjectSelect(2, block02);
//		BlockSelect(3, block03);
//		BlockSelect(4, block04);

//		ObjectRotate();
		ShowObject(blockNum);
 		if (Input.GetMouseButtonDown (0)) { //On mouse button down
			PlaceObject(blockNum);
		} 

		if (Input.GetMouseButtonDown (1)) { //On mouse button down
			ObjectRotate();
		}
	}

	public virtual void ShowObject (int num)
	{
		num = blockNum;
		if (num == 1) {
			RaycastHit rayHit; //create a RaycastHit object	
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit, Camera.main.farClipPlane)) {
				cursorCube.transform.position = rayHit.point;
				Debug.Log (rayHit.transform.name);
 			} 
		} else {
			cursorCube.transform.position = new Vector3 (10000, 10000, 10000);
		}
	}

	public virtual void PlaceObject (int num)
	{
		num = blockNum;
		
		if (num == 1) {
			RaycastHit rayHit; //create a RaycastHit object	
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit, Camera.main.farClipPlane)) {
//				GameObject cube = Instantiate (Resources.Load ("Prefabs/Cube") as GameObject);
				GameObject cube = ObjectPool.GetFromPool(Poolable.types.WALL);
				cube.transform.position = rayHit.point;
 			}  
		}
  	}

	void ObjectSelect (int num, KeyCode key)
	{
		if (Input.GetKeyDown (key)) {
			blockNum = num;
		}
	}

	public virtual void ObjectRotate (){

	}
 
}

