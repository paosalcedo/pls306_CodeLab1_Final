using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour {

	public static GameObject[] cubesPlaced;
	public static GameObject[] cornersPlaced;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		cubesPlaced = GameObject.FindGameObjectsWithTag("Cube");
		cornersPlaced = GameObject.FindGameObjectsWithTag("Corner");
	}
}
