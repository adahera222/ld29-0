// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {

    // Global instance (throughout a game).
    public static GlobalScript Instance = null;

    // Game mode
    public bool advanceLevel = false;

    public AudioClip die = null;
    public AudioClip goal = null;

	void Awake () {
        if (Instance == null) {
            print("Initialize");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
	}

    void Start() {
        print("Start: "+Application.loadedLevelName);
    }

    public void StartGame()
    {
        print("StartGame");
        Application.LoadLevel("level0");
    }

    public void PlayerDied()
    {
        print("PlayerDied");
        // Restart the current level.
        audio.clip = die;
        audio.Play();
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void PlayerReachedGoal()
    {
        print("PlayerReachedGoal");
        if (Application.loadedLevelName == "title") {
            Application.LoadLevel(Application.loadedLevelName);
            return;
        }

        // Go to the next level.
        audio.clip = goal;
        audio.Play();
        if (advanceLevel) {
            switch (Application.loadedLevelName) {
            case "level0":
                Application.LoadLevel("level1");
                break;
            case "level1":
                Application.LoadLevel("level2");
                break;
            case "level2":
                Application.LoadLevel("level3");
                break;
            default:
                Application.LoadLevel("title");
                break;
            }
        } else {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
