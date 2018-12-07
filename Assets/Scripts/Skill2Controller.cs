using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Controller : MonoBehaviour {
    public GameObject target;
    Vector3 initPos;
    Vector3 skyPos;
    public bool onSky;
    Vector3 destination;
    GameObject[] targets;
    //GameObject instance = null;
    // Use this for initialization
    void Start()
    {
        GetComponent<Collider>().enabled = false;
        targets = (FindObjectsOfType<GameObject>() as GameObject[]);
        initPos = transform.position;
        onSky = false;
        
        while(target==null){
            int i = Random.Range(0, targets.Length);
            if(targets[i].tag=="Enemy"| targets[i].tag == "Boss"){
                target = targets[i];
            }
        }

    }
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            destination = target.transform.position;
            skyPos = new Vector3(((destination - initPos) / 2).x, 5, ((destination - initPos) / 2).z);

            if (onSky)
            {
                transform.Translate((destination - transform.position) / 10);

            }
            else
            {
                transform.Translate(skyPos / 15);
                if (skyPos.y <= transform.position.y)
                {
                    onSky = true;
                    GetComponent<Collider>().enabled = true;
                }
            }
        }
        else
        {

            Destroy(gameObject);
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.transform.root.tag == "Enemy"| other.transform.root.tag == "Boss")
            {
                Destroy(gameObject);
            }

    }


}

