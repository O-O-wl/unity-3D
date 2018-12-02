using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour {
    public GameObject bamsongi; 
    public Vector3 shootTarget;
    public GameObject player;
	// Use this for initialization
	void Start () {
        shootTarget = transform.position;
        //player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    public void setTarget(Vector3 target){
        shootTarget = target;
    }
    public void shoot(){
        GameObject bamsongi = Instantiate(this.bamsongi) as GameObject;
        bamsongi.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        bamsongi.GetComponent<Rigidbody>().AddForce((shootTarget-player.transform.position).normalized * 2000);
    }
}
