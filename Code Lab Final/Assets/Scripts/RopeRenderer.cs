using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour {

	public Transform myTarget;
	public float raycastRange = 5f;
 
	Vector3 dir;

	LineRenderer lr;

	// Use this for initialization
	void Start () {
		lr = gameObject.AddComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find("Sprites/Default"));
//		lr.widthMultiplier = 0.005f;
		lr.widthMultiplier = 0.1f;
		lr.positionCount = 2;

		float a = 0.4f;
		float t = 0f;
//		Gradient gradient = new Gradient();
//		gradient.SetKeys(
//			new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.black, 1.0f) },
//			new GradientAlphaKey[] { new GradientAlphaKey(a, 0.0f), new GradientAlphaKey(t, 1.0f) }
//		);
//		lr.colorGradient = gradient;

		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.black, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(a, 1.0f), new GradientAlphaKey(t, 1.0f) }
		);
		lr.colorGradient = gradient;
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = new Ray (transform.position, dir);
		Debug.DrawRay (ray.origin, ray.direction * raycastRange, Color.red);
		
		RaycastHit rayHit = new RaycastHit ();
		
 
		if (Physics.Raycast (ray, out rayHit, raycastRange)) {
 			Vector3 reflection = Vector3.Reflect (ray.direction, rayHit.normal);
			Debug.DrawRay (rayHit.point, reflection * raycastRange, Color.blue);
			 
		}
		 
		lr.SetPosition (0, transform.position);
		lr.SetPosition (1, rayHit.point);

//		lr.SetPosition (1, myTarget.position);
		
	}
}
