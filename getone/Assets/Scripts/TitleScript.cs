// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	void Start () {
	}
	
    void Update() {
        if (GlobalScript.Instance.GetButton()) {
            // Start a game.
            GlobalScript.Instance.StartGame();
        }
    }
}
