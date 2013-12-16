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

    private float _init;

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
        _init = Time.time;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PlayerDied();
        }
    }

    public bool GetButton()
    {
        if (Time.time < _init+1) return false;
        bool button = (Input.GetButton("Horizontal") ||
                       Input.GetButton("Vertical") ||
                       Input.GetButton("Fire1") ||
                       Input.GetButton("Jump"));
        return button;
    }

    public void StartGame()
    {
        print("StartGame");
        _init = Time.time;

        Application.LoadLevel("level0");
    }

    public void PlayerDied()
    {
        print("PlayerDied");
        // Restart the current level.
        audio.clip = die;
        audio.Play();
        _init = Time.time;

        if (Application.loadedLevelName == "ending") {
            Application.LoadLevel("title");
        } else {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }

    public void PlayerReachedGoal()
    {
        print("PlayerReachedGoal");
        // Go to the next level.
        audio.clip = goal;
        audio.Play();
        _init = Time.time;

        if (!advanceLevel) {
            Application.LoadLevel(Application.loadedLevelName);
        }

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
        case "level3":
            Application.LoadLevel("level4");
            break;
        case "level4":
            Application.LoadLevel("level5");
            break;
        case "level5":
            Application.LoadLevel("ending");
            break;
        default:
            Application.LoadLevel("title");
            break;
        }
    }
}
