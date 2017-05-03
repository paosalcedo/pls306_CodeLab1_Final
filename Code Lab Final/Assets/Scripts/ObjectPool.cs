using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public static Queue<GameObject> wallPool = new Queue<GameObject>();
	public static Queue<GameObject> cornerPool = new Queue<GameObject>();

	public static GameObject GetFromPool (Poolable.types type)
	{

		GameObject result;

		if (type == Poolable.types.CORNER) {
			if (cornerPool.Count > 0) {
				result = cornerPool.Dequeue ();
				return result;
			}
			else {
				result = Instantiate (Resources.Load ("Prefabs/Cylinder") as GameObject);
				return result;

			} 
		} 
		else {
			if (wallPool.Count > 0) {
				result = wallPool.Dequeue();
				return result;

			} 

			else {
				result = Instantiate (Resources.Load ("Prefabs/Wall") as GameObject);
				return result;
 			} 
		}	
	}

	public static void AddToPool (GameObject obj)
	{
		obj.SetActive (false);
		Poolable p = obj.GetComponent<Poolable> ();
		
		if (p is PoolableCorner) {
			cornerPool.Enqueue (obj);
		} else if (p is PoolableWall) {
			wallPool.Enqueue (obj);
		} else {
			Debug.Log("you have not implemented a pool for this");
		}

	}
 
}
