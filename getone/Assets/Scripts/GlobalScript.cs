// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {

    // Global instance (throughout a game).
    public static GlobalScript Instance = null;

    public AudioClip die = null;

	void Awake () {
        if (Instance == null) {
            print("Initialize");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
	}

    public void PlayerDied()
    {
        print("PlayerDied");
        audio.clip = die;
        audio.Play();
        Application.LoadLevel("main");
    }

    public void PlayerReachedGoal()
    {
        print("PlayerReachedGoal");
        Application.LoadLevel("main");
    }
}
