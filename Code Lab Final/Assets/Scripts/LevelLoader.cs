using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

  	public float offsetX = 0;
	public float offsetY = 0;
//	public float offsetZ = 0;

	 
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

//		StreamReader sr = new StreamReader (filePath);

		StreamReader sr = new StreamReader(new MemoryStream((Resources.Load(fileName) as TextAsset).bytes));

		GameObject levelHolder = new GameObject ("Level Holder");

//		int zPos = 0;
		int yPos = 0;

		//Read from level text files.
		while (!sr.EndOfStream) {
			string line = sr.ReadLine ();

			for (int xPos = 0; xPos < line.Length; xPos++) {

				if (line [xPos] == 'x') {
					GameObject wall = Instantiate (Resources.Load ("Prefabs/Wall") as GameObject);

					wall.transform.parent = levelHolder.transform;

					wall.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + offsetY,
						0						
					);
				}
			
				//Instantiate Player
				if (line [xPos] == 'p') { 
					GameObject player = Instantiate (Resources.Load ("Prefabs/Particle") as GameObject);
					player.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + offsetY,
						0		
					);
				}
			
				if (line [xPos] == 'g') {
					GameObject floor = Instantiate (Resources.Load ("Prefabs/Goal") as GameObject);
					floor.transform.position = new Vector3 (
						xPos + offsetX, 
						yPos + offsetY,
						0		
					);
				}

			}
			
			yPos--;
		}

		sr.Close();
	}

	public static bool playerIsAtGoal;
	public static bool gameIsOver;
	// Update is called once per frame
	void Update ()
	{
		if (playerIsAtGoal) { //resets time to 30s (user-selected)
			TimeKeeper.timeLeft = TimeKeeper.timeAtLevelStart;
			LoadNextLevel ();
		}
		
		if (Input.GetKeyDown (KeyCode.R)) {
			RestartCurrentLevel();
		}
	}

	void LoadNextLevel ()
	{
		levelNum++;
 		SceneManager.LoadScene ("main");
	}

	void RestartCurrentLevel(){
		SceneManager.LoadScene("main");
	}

	public static void LoadGameOver(){
		levelNum = 9;
		TimeKeeper.timeAtLevelStart = 10f;
		SceneManager.LoadScene("main");
	}

	public static void RestartScene(){
		levelNum = 0;
		SceneManager.LoadScene("main");
	}

//
//	void EndLevel ()
//	{
//		enemies = GameObject.FindGameObjectsWithTag("Enemy");
//
//		foreach (GameObject 
//	}
}