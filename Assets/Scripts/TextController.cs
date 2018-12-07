using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextController : MonoBehaviour {

    float timev=1;
    float timedelta;
    bool go;
    Vector3 initLoc;
	// Use this for initialization
	void Start () {
        timedelta = 0;
        go = false;
        initLoc = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
      //  transform.rotation = GameObject.Find("Main Camera").transform.rotation;

            timedelta += Time.deltaTime;
            transform.Translate(0, 0.2f, 0);
            if (timedelta>timev){

                timedelta = 0;
                go = false;
                Destroy(gameObject);

            }
      
    }

}
