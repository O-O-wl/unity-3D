using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalController : MonoBehaviour
{
    bool destroy = false;
    float destroyDelta = 0;
    float destroySpan = 10;
    public GameObject golemPrefab;
    public bool onBoss = false;
   public bool goShaqe = false;
   public bool oneTime = true;
    GameObject golem;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Main Camera").GetComponent<FollowCamera>().lookTarget = GameObject.Find("Player").transform;
        if (onBoss)
        {
            golem= Instantiate(golemPrefab) as GameObject;
            golem.transform.position = new Vector3(-44, 0, 44);
            onBoss = false;
            GameObject.Find("Main Camera").GetComponent<FollowCamera>().BossStage();
            GameObject.Find("Main Camera").GetComponent<FollowCamera>().distance = 25;

        }
        if (destroy)
        {
            destroyDelta += Time.deltaTime;
            GameObject.Find("Main Camera").GetComponent<FollowCamera>().distance = 6+destroyDelta*2;
            if (destroyDelta > destroySpan){
                   //GameObject.Find("Main Camera").GetComponent<FollowCamera>().distance = 25;
                // golemPrefab.GetComponent<CharacterMove>().destination = golem.transform.position;
                golem.GetComponent<AttackAreaActivator>().enabled = true;
                golem.GetComponent<EnemyCtrl>().enabled = true;
                golem.GetComponent<DragonAttack>().enabled = true;
                golem.GetComponent<CharacterStatus>().enabled = true;
                golem.GetComponent<CharacterMove>().enabled = true; destroy = false;
                GameObject.Find("Main Camera").GetComponent<FollowCamera>().distance =10;

            }
            GameObject.Find("Main Camera").GetComponent<FollowCamera>().lookTarget = golem.transform;



        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if( other.tag=="Player" & oneTime){
            destroy = true;
            onBoss = true;
            oneTime = false;
        }
        
    }
    /*
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.root.tag=="Player"){
                destroy = true;

                other.transform.root.GetComponent<CharacterMove>().destination = new Vector3(-39, 0, -31);
            }
        }
    */
}
