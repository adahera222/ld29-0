// -*- tab-width: 4 -*-
using UnityEngine;
using System.Collections;

public class AngleTriggerScript : MonoBehaviour {

    public Transform target = null;
    public bool multiple = false;

    public float angleLower = 0f;
    public float angleUpper = 360f;

    private bool _active = false;
    private bool _triggered = false;

	void Start () {
	}
	
    void Update() {
        float angle = transform.rotation.eulerAngles.z;
        bool active = (angleLower <= angle && angle <= angleUpper);
        if (active && !_active) {
            _active = true;
            TriggerObject();
        } else {
            _active = false;
        }
    }

    void TriggerObject() {
        if (!multiple && _triggered) return;
        _triggered = true;
        if (target != null) {
            target.gameObject.SendMessage("Activate", gameObject,
                                          SendMessageOptions.DontRequireReceiver);
        } else {
            gameObject.SendMessage("Activate", gameObject,
                                   SendMessageOptions.DontRequireReceiver);
        }
        if (audio != null && audio.clip != null) {
            audio.Play();
        }
    }
}
