using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour {
    Vector3 target=new Vector3(50,0,-70);
    Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {
        transform.Translate(target.normalized);

	}

    void setTarget(Vector3 target){
        this.target = target;
    }
}

