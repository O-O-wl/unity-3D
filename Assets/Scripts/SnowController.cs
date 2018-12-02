using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(-90, 0, 0);
        transform.Translate(Random.RandomRange(-0.1f, 0.1f),-0.2f, Random.RandomRange(-0.1f, 0.1f));
        transform.Rotate(90, 0, 0);
        if (transform.position.y < -1) { Destroy(gameObject); }
		
	}
}
