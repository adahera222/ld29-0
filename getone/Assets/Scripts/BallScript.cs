// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public Transform ball = null;
	public Animator anim = null;

	public float rotationSpeed = 1.0f;

    private int _landed = 0;

	void Start () {
		anim.SetFloat("Speed", 0f);
	}
	
	void Update () {
        float rot = rigidbody2D.angularVelocity * Time.deltaTime * rotationSpeed;
		ball.Rotate(new Vector3(0, 0, -rot));
		anim.SetFloat("Speed", Mathf.Abs(rot));
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
