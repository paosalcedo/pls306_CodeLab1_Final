using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableWall : Poolable {

	public float timeAlive;
 
	public override void Setup ()
	{
 	}

	void Start(){
		timeAlive = 1f;
 	}
	void Update ()
	{
 		timeAlive -= Time.deltaTime;
	}

	public override bool RePool ()
	{
		//put back in pool if this is true. 
		//perhaps if it's off cam?  

		return timeAlive <= 0;
 	}

	public override void Reset ()
	{
 		transform.position = GameObject.FindGameObjectWithTag("CursorCube").transform.position;
	}
}
