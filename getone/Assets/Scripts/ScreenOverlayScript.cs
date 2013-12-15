// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class ScreenOverlayScript : MonoBehaviour {

    // Text style.
    public GUIStyle textStyle = new GUIStyle();

    private float _t0;
    
    void Start() {
        _t0 = Time.time;
    }

    void OnGUI() {
        float t = Time.time-_t0;
        System.String s = System.String.Format("{0:0.00}s", t);
        Rect r = getCenterRect(0.1f, 0.1f, 0.2f, 0.1f);
        GUI.Label(r, s, textStyle);
    }

    // getCenterRect(x, y, w, h):
    Rect getCenterRect(float x, float y, float w, float h)
    {
        return new Rect(Screen.width*(x-w/2), Screen.height*(y-h/2), 
                        Screen.width*w, Screen.height*h);
    }

}
