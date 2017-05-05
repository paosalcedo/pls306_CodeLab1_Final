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
	void Update ()
	{
		if (LevelLoader.levelNum <= 6) { //normal levels
			timeAtLevelStart -= Time.deltaTime;
			if (timeAtLevelStart <= 0) {
				LevelLoader.RestartScene ();
			}
		} else { // game over and you win levels.
 			timeAtLevelStart -= Time.deltaTime;
			if (timeAtLevelStart <= 0) {
				LevelLoader.RestartScene ();
			}
		}
		ShowTimer();
	}

	void ShowTimer ()
	{
		if (LevelLoader.levelNum <= 7) { 
			timeText.text = timeAtLevelStart.ToString ("Time Left: " + "##");
		} else {
			timeText.text = timeAtLevelStart.ToString ("Restarting game in " + "##");
		}
	}

}
