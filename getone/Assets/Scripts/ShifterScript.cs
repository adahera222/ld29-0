// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ShifterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            BallScript script = coll.gameObject.GetComponent<BallScript>();
            script.arrow.rotation = transform.rotation;
            audio.Play();
            break;
        }
    }
}
