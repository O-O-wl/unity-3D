using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour {
    public GameObject snow;
    GameObject snowInstance;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        snowInstance = Instantiate(snow) as GameObject;
        snowInstance.transform.position = new Vector3(Random.RandomRange(-100, 100), 10, Random.RandomRange(-100, 100));

        snowInstance = Instantiate(snow) as GameObject;
        snowInstance.transform.position= new Vector3(Random.RandomRange(-100 ,100), 10, Random.RandomRange(-100, 100));
	}
}
