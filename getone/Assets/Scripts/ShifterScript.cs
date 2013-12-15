// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ShifterScript : MonoBehaviour {

	void Start () {
	}
	
    void Activate(GameObject obj) {
        // Change the ball direction.
        Transform player = obj.GetComponent<Transform>().parent;
        PlayerScript script = player.gameObject.GetComponent<PlayerScript>();
        script.Shift(transform);
    }
}
