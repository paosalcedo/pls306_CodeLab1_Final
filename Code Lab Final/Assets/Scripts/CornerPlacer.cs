using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerPlacer : ObjectPlacer {

	GameObject cursorCorner;

	void Start () {
		cursorCorner = Instantiate (Resources.Load ("Prefabs/CursorCorner") as GameObject);
		cursorCorner.transform.position = new Vector3 (10000, 10000, 10000);
 	}

//	void Update ()
//	{
//		if (Input.GetMouseButtonDown (1)) {
//			ObjectRotate ();
//		}
//	}

	public override void ShowObject (int num)
	{
		num = blockNum;
		if (num == 2) {
			RaycastHit rayHit; //create a RaycastHit object	
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit, Camera.main.farClipPlane)) {
				cursorCorner.transform.position = rayHit.point;
				Debug.Log (rayHit.transform.name);
			}
		}
 		else {
			cursorCorner.transform.position = new Vector3 (10000, 10000, 10000);
		}
	}

	public override void PlaceObject (int num)
	{
		num = blockNum;
		if (num == 2) {
			RaycastHit rayHit; //create a RaycastHit object		
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit, Camera.main.farClipPlane)) {
				GameObject corner = Instantiate (Resources.Load ("Prefabs/Corner") as GameObject);
				corner.transform.position = rayHit.point;
				corner.transform.eulerAngles = cursorCorner.transform.eulerAngles;
				Debug.Log (rayHit.transform.name);
			} else {
				Debug.Log ("hit nothing!");
			}
		}
	}

	public override void ObjectRotate(){
		cursorCorner.transform.eulerAngles = new Vector3 (	cursorCorner.transform.eulerAngles.x,
															cursorCorner.transform.eulerAngles.y,
															cursorCorner.transform.eulerAngles.z + 90f);
	}

}
