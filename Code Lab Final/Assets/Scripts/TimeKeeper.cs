using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour {

	public Text timeText;

	public List<float> levelTimes = new List<float>();
	public static float timeAtLevelStart;
	public static float timeLeft;
  	
 	// Use this for initialization
	void Start ()
	{
		Debug.Log("Loaded level " + LevelLoader.levelNum);
 		timeAtLevelStart = levelTimes[LevelLoader.levelNum] + timeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		timeAtLevelStart -= Time.deltaTime;
		ShowTimer();
	}

	void ShowTimer ()
	{
  		timeText.text = timeAtLevelStart.ToString ("Time Left: " + "##");
	}
}
