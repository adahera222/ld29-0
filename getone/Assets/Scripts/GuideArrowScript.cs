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
        Vector2 pos0 = new Vector3(transform.position.x, transform.position.y, 0);
        Vector2 pos1 = new Vector3(_goal.position.x, _goal.position.y, 0);
        float angle = Vector2.Angle(Vector2.right, pos1-pos0);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
