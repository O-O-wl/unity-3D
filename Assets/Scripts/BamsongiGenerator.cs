using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour {
    public GameObject bamsongi;
    public GameObject bamsongi2;
    public Vector3 shootTarget;
    public GameObject player;
  
    public float  fireTime=0.3f;
    public float firedelta;
    public bool fire;
    float key;
	// Use this for initialization
	void Start () {
        shootTarget = transform.position;
        firedelta = 0;
        fire = false;
        //player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        key = Random.Range(0, 10);
        if(fire){
            firedelta += Time.deltaTime;
            if(firedelta>fireTime){
                Debug.Log(key);
                GameObject bamsongi = Instantiate(((key)>=8)?this.bamsongi2:this.bamsongi) as GameObject;
                bamsongi.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.3f, player.transform.position.z);
                bamsongi.GetComponent<Rigidbody>().AddForce((shootTarget - player.transform.position).normalized * 2000);
                key = Random.RandomRange(0, 3);
                fire = false;
                firedelta = 0;
            }
        }
		
	}
    public void setTarget(Vector3 target){
        shootTarget = target;
    }
    public void shoot(){
        fire = true;
         }
}
