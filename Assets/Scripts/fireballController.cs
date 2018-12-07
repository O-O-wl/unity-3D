using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballController : MonoBehaviour {

    float effectTime = 4;
    float delta = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        if(delta>effectTime){
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag=="Player"){
            Debug.Log("ok2");
            other.gameObject.transform.root.GetComponent<CharacterController>().Move(new Vector3(GetComponent<Rigidbody>().velocity.x,0, GetComponent<Rigidbody>().velocity.z) * 0.1f);
                 /*. rigidbody.AddForce(new Vector3(GetComponent<Rigidbody>().velocity.x,0, GetComponent<Rigidbody>().velocity.z) * 1000f);
           */Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ok");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * 10000f);
            Destroy(gameObject);
        }
    }
}
