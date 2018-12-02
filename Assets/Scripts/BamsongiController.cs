using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour {
    public Vector3 target;
    Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
   //     rigidbody.AddForce((target - transform.position).normalized * 100);
		
	}
    public void  setShoot(Vector3 target){
  //      this.target = target;
    }
    public void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }
}
