// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public Transform ball = null;
	public Animator anim = null;

	public float rotationSpeed = 1.0f;

    private int _landed = 0;

	void Start () {
        ball.rotation = Quaternion.identity;
		anim.SetFloat("Speed", 0);
	}
	
	void Update () {
        float rot = rigidbody2D.angularVelocity * Time.deltaTime * rotationSpeed;
        float vx = transform.localScale.x;
		ball.Rotate(new Vector3(0, 0, -vx*rot));
		anim.SetFloat("Speed", Mathf.Abs(rot));
	}

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
        case "Landable":
            if (_landed == 0) {
                audio.Play();
            }
            _landed++;
            break;

        case "Container":
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
        case "Landable":
        case "Container":
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

    // SetDirection(dx)
    public bool SetDirection(float dx) {
        Vector3 scale = transform.localScale;
        if ((0 < scale.x && dx < 0) ||
            (scale.x < 0 && 0 < dx)) {
            transform.localScale = new Vector3(dx, scale.y, scale.z);
            ball.rotation = Quaternion.identity;
            return true;
        }
        return false;
    }
}
