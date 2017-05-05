using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableWall : Poolable {

	
	public override void Setup ()
	{
		Debug.Log("SETUP!");
	}

//	public override bool RePool ()
//	{
//// 		return true;
// 	}

	public override void Reset ()
	{
		Debug.Log("RESETTING!");
		transform.position = GameObject.FindGameObjectWithTag("CursorCube").transform.position;
	}
}
