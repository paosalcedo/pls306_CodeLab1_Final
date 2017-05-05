using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Poolable : MonoBehaviour {

	public enum types {
		CORNER, WALL
	}

	void Start () {
		Setup();
	}
	
 	void Update ()
	{
// 		if(RePool()){
//			Debug.Log("SOMETHING GOT REPOOLED in POOLABLE.CS");
//			ObjectPool.AddToPool(gameObject); 
// 		}	
	
	}

	public abstract void Setup();

//	public abstract bool RePool();

	public abstract void Reset();

}
