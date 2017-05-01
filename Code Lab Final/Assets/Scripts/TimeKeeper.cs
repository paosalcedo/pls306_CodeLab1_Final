using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {

	public static TimeKeeper instance;

	public float gameTime;

	// Use this for initialization
	void Start ()
	{
		if (instance == null) {
			instance = this;
		} else {
			DontDestroyOnLoad(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;
	}
}
