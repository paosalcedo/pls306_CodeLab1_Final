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
 		if(RePool()){
			ObjectPool.AddToPool(gameObject); 
  		}	
	
	}

	public abstract void Setup();

	public abstract bool RePool();

	public abstract void Reset();

}
