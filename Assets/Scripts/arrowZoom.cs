using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowZoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.R)){
            transform.Rotate(-45, -90, 0);
            transform.position = new Vector3(0, -1, 1);
        }
        if(Input.GetKey(KeyCode.R)){



        }
	}

}
