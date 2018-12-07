using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour {
    public Vector3 target;
    Rigidbody rigidbody;
    float delta;
    float span = 3;
	// Use this for initialization
	void Start () {
        target = transform.position;
        delta = 0;
	}
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        if (delta > span) { Destroy(gameObject); }
   //     rigidbody.AddForce((target - transform.position).normalized * 100);
		
	}
    public void  setShoot(Vector3 target){
  //      this.target = target;
    }
    public void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }
    public void OnTriggerStay(Collider other)
    {
        Destroy(gameObject);
    }
}
