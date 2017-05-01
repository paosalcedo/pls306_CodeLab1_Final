using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerPlacer : ObjectPlacer {

	public override void PlaceObject (int num)
	{
		num = blockNum;
		if (num == 2) {
			RaycastHit rayHit; //create a RaycastHit object		
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rayHit, Camera.main.farClipPlane)) {
				GameObject corner = Instantiate (Resources.Load ("Prefabs/Corner") as GameObject);
				corner.transform.position = rayHit.point;
				Debug.Log (rayHit.transform.name);
			} else {
				Debug.Log ("hit nothing!");
			}
		}
	}

}
