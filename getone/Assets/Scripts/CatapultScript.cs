// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class CatapultScript : MonoBehaviour {

	void Start () {
	
	}
	
    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Ball":
            audio.Play();
            break;
        }
    }
}
