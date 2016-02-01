﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform Target;
    public float MovementSpeed = 0.05f;
    Camera myCamera;

    void Start () {
        myCamera  = GetComponent<Camera>();
	}
	
	void Update () {
        myCamera.orthographicSize = Screen.height / 100f / 4f;

        if (Target)
            transform.position = Vector3.Lerp(transform.position, Target.position, MovementSpeed) + new Vector3(0, 0, -10);
	}
}
