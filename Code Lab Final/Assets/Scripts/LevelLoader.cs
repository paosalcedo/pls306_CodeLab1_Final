using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	GameObject enemy;
	GameObject[] enemies;
	public float offsetX = 0;
	public float offsetZ = 0;
	public float coinOffsetY;
	public float lightOffsetY;
	
	public float tileZ;

	public string[] fileNames;
	public static int levelNum = 0;

	// Use this for initialization
	void Start ()
	{	

//		GameOverCheck();
//		Debug.Log("Lives left: " + LivesKeeper.instance.Lives);
		
		//looking for all enemies.
//		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		Cursor.visible = true;		
		Cursor.lockState = CursorLockMode.Confined;

		string fileName = fileNames [levelNum];

		string filePath = Application.dataPath + "/" + fileName;

		StreamReader sr = new StreamReader (filePath);

		GameObject levelHolder = new GameObject ("Level Holder");

		int zPos = 0;
		int yPos = 0;

		//Read from level text files.
		while (!sr.EndOfStream) {
			string line = sr.ReadLine ();

			for (int xPos = 0; xPos < line.Length; xPos++) {

				if (line [xPos] == 'x') {
					GameObject wall = Instantiate (Resources.Load ("Prefabs/Cube01") as GameObject);

					wall.transform.parent = levelHolder.transform;

					wall.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos,
						zPos + offsetZ 
						);
				}
			
				//Instantiate Player
				if (line [xPos] == 'p') { 
					GameObject player = Instantiate (Resources.Load ("Prefabs/Player") as GameObject);
					player.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos,
						zPos + offsetZ
						);
				}

				//instantiate platforms
				if (line [xPos] == 'i') { 
					GameObject platform = Instantiate (Resources.Load ("Prefabs/Platform") as GameObject);
					platform.transform.parent = levelHolder.transform;
					platform.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos,
						zPos + offsetZ
					);
				}

				//Instantiate lights with platform.
				if (line [xPos] == '*') {
					GameObject platform = Instantiate (Resources.Load ("Prefabs/Platform") as GameObject);
					platform.transform.parent = levelHolder.transform;
					platform.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos,
						zPos + offsetZ
					);

					GameObject light = Instantiate (Resources.Load ("Prefabs/Light") as GameObject);
					light.transform.parent = levelHolder.transform;
					light.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + lightOffsetY,
						zPos + offsetZ
					);
				}

				if (line [xPos] == '^') {
					GameObject light = Instantiate (Resources.Load ("Prefabs/Light") as GameObject);
					light.transform.parent = levelHolder.transform;
					light.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + lightOffsetY,
						zPos + offsetZ
					);
				}
				

				//Instantiate coins
				if (line [xPos] == 'c') {
					GameObject platform = Instantiate (Resources.Load ("Prefabs/Platform") as GameObject);
					platform.transform.parent = levelHolder.transform;
					platform.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos,
						zPos + offsetZ
					);

					GameObject light = Instantiate (Resources.Load ("Prefabs/Light") as GameObject);
					light.transform.parent = levelHolder.transform;
					light.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + lightOffsetY,
						zPos + offsetZ
					);

					GameObject coin = Instantiate (Resources.Load ("Prefabs/Coin") as GameObject);
					coin.transform.parent = levelHolder.transform;
					coin.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + coinOffsetY,
						zPos + offsetZ
					);
				}

				//Instantiate goal area.
				if (line [xPos] == 'g') { 
					GameObject goal = Instantiate (Resources.Load ("Prefabs/Goal") as GameObject);
					goal.transform.parent = levelHolder.transform;
					goal.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos,
						zPos + offsetZ
					);

					GameObject light = Instantiate (Resources.Load ("Prefabs/Light") as GameObject);
					light.transform.parent = levelHolder.transform;
					light.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + lightOffsetY,
						zPos + offsetZ
					);
				}

				if (line [xPos] == '|') { 
					yPos -= 4;
					offsetZ += 17;
				}

			}
			
			zPos--;
		}

		sr.Close();
	}


	float timeAtEndOfLevel;

	// Update is called once per frame
	void Update () {

	}

	void LoadNextLevel ()
	{
		levelNum++;
		ScoreKeeper.instance.Score = 0;
		SceneManager.LoadScene ("first");

	}

//
//	void EndLevel ()
//	{
//		enemies = GameObject.FindGameObjectsWithTag("Enemy");
//
//		foreach (GameObject 
//	}
}