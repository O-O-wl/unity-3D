using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChar : MonoBehaviour {
    GameObject Sword1;
    GameObject Shield01;
    GameObject hat;
    GameObject Before;
    CharacterStatus status;
    GameObject Gunner;
    GameObject Player;
    GameObject Cameraa;
    TargetCursor targetCursor;
    // Use this for initialization
    void Start () {
        Shield01 = GameObject.Find("Shield01");
        Sword1 = GameObject.Find("Sword01");
        hat = GameObject.Find("Hat");
        Before = GameObject.Find("Before");
        Gunner=GameObject.Find("Gunner");
        Gunner.active = false;
        Player = GameObject.Find("Player");
        status = GetComponent<CharacterStatus>();
        Cameraa=GameObject.Find("Main Camera");
        targetCursor = FindObjectOfType<TargetCursor>();
    }
    
    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            status.trans = true;
            Sword1.active = false;
            Shield01.active = false;
            hat.active = false;
            Before.active = false;
            Gunner.active = true;
            targetCursor.enabled = false;
            Player.GetComponent<PlayerControllerer>().enabled = true;
            Player.GetComponent<GunnerController>().enabled = true;
            Player.GetComponent<CharacterMove>().destination = Player.transform.position;
            Player.transform.rotation = Player.GetComponent<PlayerCtrl>().initLOC;
           /*
            Cameraa.transform.SetParent(Player.transform);
            Cameraa.transform.position = new Vector3(-0.1f, 4, -11);
            Cameraa.transform.localRotation= Quaternion.Euler(Vector3(10,0,0))
            Cameraa.GetComponent<FollowCamera>().enabled = false;
            Cameraa.GetComponent<FollowCam>().enabled = true;
         */
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            status.trans = false;
            Sword1.active = true;
            Shield01.active = true;
            hat.active = true;
            Before.active = true;
            Gunner.active = false;
            targetCursor.enabled = true;
            Player.GetComponent<CharacterMove>().destination = Player.transform.position;
            Player.transform.rotation = Player.GetComponent<PlayerCtrl>().initLOC;
            Player.GetComponent<PlayerControllerer>().enabled=false;
            Player.GetComponent<GunnerController>().enabled = false;
            /*
             Cameraa.transform.SetParent(Player.transform);
             Cameraa.transform.position = new Vector3(-0.1f, 4, -11);
             Cameraa.transform.localRotation= Quaternion.Euler(Vector3(10,0,0))
             Cameraa.GetComponent<FollowCamera>().enabled = false;
             Cameraa.GetComponent<FollowCam>().enabled = true;
          */
        }

    }
}
