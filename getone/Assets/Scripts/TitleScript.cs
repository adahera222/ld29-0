// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	void Start () {
	}
	
    void Update() {
        bool button = (Input.GetButton("Horizontal") ||
                       Input.GetButton("Vertical") ||
                       Input.GetButton("Fire1") ||
                       Input.GetButton("Jump"));
        if (button) {
            // Start a game.
            GlobalScript.Instance.StartGame();
        }
    }
}
