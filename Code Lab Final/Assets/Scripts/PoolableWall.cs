using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableWall : Poolable {

	GameObject player;

	public override void Setup ()
	{
		player = GameObject.Find("Player");		
	}

	public override bool RePool(){
		//put back in pool if this is true. 
		//perhaps if it's off cam?  

		return true;
	}

	public override void Reset ()
	{
		if (player == null) {
			player = GameObject.Find("Player");
		}
	}
}
