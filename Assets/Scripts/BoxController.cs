using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
    public GameObject Slime;
    Animator anim;
    bool open = false;
    float animationDelta;
    float animaionSpan;
    bool startAnmi;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        animaionSpan = 4f;
        startAnmi = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (startAnmi)
        {
            animationDelta += Time.deltaTime;
        }
        if (animationDelta >= animaionSpan)
        {
            Destroy(gameObject);
            GameObject Slime = Instantiate(this.Slime) as GameObject;
            Slime.transform.position = transform.position;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")

        if(other.GetComponent<CharacterStatus>().haveKey){
                if (!startAnmi)
                {
                    GetComponent<OpenAnimTest>().openBox();
                    startAnmi = true;
                }

              
        }

    }
}
