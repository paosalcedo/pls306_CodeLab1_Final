using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableCorner : Poolable {

//	GameObject player;

 
	public override void Setup ()
	{
//		player = GameObject.Find("Player");		
	}

//	public override bool RePool(){
//		//put back in pool if this is true. 
//		//perhaps if it's off cam?  
////		Debug.Log("repooooool mah CORNER!");
////		return ObjectPool.cornerPool.Count > 1;
//		return true;
//	}

	public override void Reset ()
	{
//		Debug.Log("reseeeeeeet CORNER!!!");
		transform.position = GameObject.FindGameObjectWithTag("CursorCorner").transform.position;
	}
}
