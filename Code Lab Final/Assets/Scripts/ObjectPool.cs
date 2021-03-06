﻿using System.Collections;
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
				Debug.Log("corner dequeued!");
				result = cornerPool.Dequeue ();
				return result;
			}
			else {
				result = Instantiate (Resources.Load ("Prefabs/Corner") as GameObject);
				return result;
			} 
		} 
		else {
			if (wallPool.Count > 0) {
				Debug.Log("cube dequeued!");
				result = wallPool.Dequeue();
				return result;
			} 

			else {
				result = Instantiate (Resources.Load ("Prefabs/Cube") as GameObject);
				return result;
 			} 
		}

		result.SetActive(true);
		result.GetComponent<Poolable>().Reset();
		return result;	
	}

	public static void AddToPool (GameObject obj)
	{
		obj.SetActive (false);
//		Poolable p = obj.GetComponent<Poolable> ();
//		
//		if (p is PoolableCorner) {
//			cornerPool.Enqueue (obj);
//			Debug.Log("corner enqueued!");
//		} else if (p is PoolableWall) {
//			wallPool.Enqueue (obj);
////			Debug.Log("cube enqueued!");
//
//		} else {
//			Debug.Log("you have not implemented a pool for this");
//		}

	}
 
}
