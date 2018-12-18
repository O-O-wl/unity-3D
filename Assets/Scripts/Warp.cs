using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {
    GameObject portal2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.tag=="Player"){
            portal2 = GameObject.Find("portal2(Clone)");
            other.transform.position = portal2.transform.position;
            other.GetComponent<CharacterMove>().destination = portal2.transform.position;
        }
    }

}
