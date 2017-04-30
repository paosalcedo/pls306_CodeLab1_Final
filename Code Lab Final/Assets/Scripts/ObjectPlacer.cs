using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlaceObject();
	}

	void PlaceObject(){
		if(Input.GetMouseButtonDown(0)){ //On mouse button down
			RaycastHit rayHit; //create a RaycastHit object
			
 			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Camera.main.farClipPlane)){
				GameObject block = Instantiate (Resources.Load("Prefabs/Wall") as GameObject);
				block.transform.position = rayHit.point;
				Debug.Log(rayHit.transform.name);
 			} else {
				Debug.Log("hit nothing!");
			}
		}
	}
}

