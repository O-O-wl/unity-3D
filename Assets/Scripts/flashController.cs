using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashController : MonoBehaviour {
    Behaviour halo;
    bool onoff = false;
    float flinking = 0;
    float onoffSpan = 3;
    // Use this for initialization
    void Start () {
        halo = (gameObject.GetComponent("Halo") as Behaviour);

    }
	
	// Update is called once per frame
	void Update () {

        flinking += Time.deltaTime;
        if(flinking>onoffSpan){
            flinking = 0;
            onoff = true;
        }
        if(onoff)
        {
            onoff = false;
            halo.enabled=halo.enabled? halo.enabled = false : halo.enabled = true;
        }
		
	}
}
