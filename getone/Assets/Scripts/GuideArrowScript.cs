// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class GuideArrowScript : MonoBehaviour {

    public GUIStyle textStyle = new GUIStyle();

    private Transform _goal;

	void Start () {
        // Find a Goal object automatically.
        GameObject obj = GameObject.FindWithTag("Goal");
        if (obj != null) {
            _goal = obj.transform;
        }
	}
	
	void Update () {
        // Point the goal.
        if (_goal != null) {
            float dx = _goal.position.x - transform.position.x;
            float dy = _goal.position.y - transform.position.y;
            float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
	}

    void OnGUI() {
        Rect r = getCenterRect(0.1f, 0.85f, 0.1f, 0.1f);
        GUI.Label(r, "Goal", textStyle);
    }

    Rect getCenterRect(float x, float y, float w, float h)
    {
        return new Rect(Screen.width*(x-w/2), Screen.height*(y-h/2), 
                        Screen.width*w, Screen.height*h);
    }
}
