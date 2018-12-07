﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    public Transform targetTr;
    public float distance = 10.0f;
    public float height = 3.0f;
    public float dampTrace = 20.0f;

    private Transform tr;

    // Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();

		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        tr.position = Vector3.Lerp(tr.position,
                                 targetTr.position
                                 - (targetTr.forward * distance)
                                 + (Vector3.up * height), Time.deltaTime * dampTrace);
	}
}