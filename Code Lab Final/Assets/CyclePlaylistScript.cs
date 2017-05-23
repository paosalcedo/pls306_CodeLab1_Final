using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclePlaylistScript : MonoBehaviour {

	public List<AudioClip> tracks;
	int currentTrack;
	int lastPlayed;
	AudioSource source;

	public static CyclePlaylistScript instance;

	// Use this for initialization
	void Start () {
		currentTrack = Random.Range (0, 2);
		lastPlayed = currentTrack;
		source = GetComponent<AudioSource> ();
		source.clip = tracks [currentTrack];
		source.PlayScheduled (AudioSettings.dspTime);
		source.loop = true;
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
