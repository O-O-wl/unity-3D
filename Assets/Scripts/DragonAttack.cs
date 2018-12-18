using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour {
    public GameObject fireball;
    float fireballDelta;
    float fireballCoolTime=3;
    bool effect = false;
    float effectDelta = 0;
    float effectSpan = 0.5f;
    float startSpan = 12;
    float startDelta = 0;

	// Use this for initialization
	void Start () {
        fireballDelta = 0;	}
	
	// Update is called once per frame
	void Update () {
        if(startDelta<startSpan)
        {
            startDelta += Time.deltaTime;
            return;
        }
        else{

        if(effect){
            effectDelta += Time.deltaTime;
            if(effectDelta>=effectSpan){
                effectDelta = 0;
                effect = false;
                (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
            }

        }
        fireballDelta += Time.deltaTime;
            if (fireballDelta >= fireballCoolTime)
            {

                (gameObject.GetComponent("Halo") as Behaviour).enabled = true;
                effect = true;
                for (int i = 0; i < 10; i++)
                {
                    GameObject fireball = Instantiate(this.fireball) as GameObject;
                    fireball.transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
                    fireball.GetComponent<Rigidbody>().AddForce((new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)).normalized * 1000));

                }

                fireballDelta = 0;
            }                                      
        }
          
	}
}
