// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    private int _landed = 0;

	void Start () {
	}

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Floor":
            audio.Play();
            _landed++;
            break;

        case "Enemy":
            // Hit an enemy.
            GlobalScript.Instance.PlayerDied();
            break;
        }
    }

    void OnCollisionExit2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Floor":
            _landed--;
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "Goal":
            // Reached the goal.
            GlobalScript.Instance.PlayerReachedGoal();
            break;
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        switch (coll.gameObject.tag) {
        case "SafeZone":
            // Go outside the safe zone.
            GlobalScript.Instance.PlayerDied();
            break;
        }
    }

    // Accel(v)
    public void Accel(Vector2 v) {
        if (0 < _landed) {
            rigidbody2D.AddForce(v);
        }
    }
}
