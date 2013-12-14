// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class GuideArrowScript : MonoBehaviour {

    private Transform _goal;

	void Start () {
        // Find a Goal object automatically.
        GameObject obj = GameObject.FindWithTag("Goal");
        _goal = obj.transform;
	}
	
	void Update () {
        // Point the goal.
        float dx = _goal.position.x - transform.position.x;
        float dy = _goal.position.y - transform.position.y;
        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
