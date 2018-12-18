using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
    public int enemyCount;
    public int stage;
    public GameObject stageBackground;
    public GameObject stageUI;
    public GameObject Player;
    public GameObject portal;
    public GameObject portal2;
    public GameObject CAMeRA;
    public float stageChangeDelta;
    bool changeStage;
    GameObject enemyCountUI;
    bool portalFocus = false; 
    float focusDelta = 0;
    float focusSpan = 2;
    // Use thisint for initialization
    void Start () {
        changeStage = true;
        CAMeRA = GameObject.Find("Main Camera");
        enemyCount = 0;
        Player = GameObject.Find("Player");
        stage = 1;
       
        enemyCountUI = GameObject.Find("EnemyKillCount");
        stageChangeDelta = 0;
        stageUI = GameObject.Find("Stage");
        stageBackground = GameObject.Find("StageBackground");
        // GameObject.Find("EnemyGenerator").GetComponent<EnemyGeneratorCtrl>().setEnemyWarg();

	}
    private void LateUpdate()
    {
        if (portalFocus)
        {
            //    CAMeRA.GetComponent<Transform>().position=new Vector3
            focusDelta += Time.deltaTime;
            CAMeRA.transform.position = new Vector3(40, 10, -35);
            if (focusSpan < focusDelta)
            {
                CAMeRA.GetComponent<FollowCamera>().lookTarget = Player.transform;
                CAMeRA.transform.position = CAMeRA.GetComponent<FollowCamera>().initLoc;
                portalFocus = false;
            }
        }
    }
    // Update is called once per frame
    void Update () {

        if (stage == 3)
        {
            enemyCountUI.GetComponent<Text>().text = enemyCount + "/1";
            if(enemyCount==1){
                GameObject portal= Instantiate(this.portal) as GameObject;
                GameObject portal2= Instantiate(this.portal2) as GameObject;
                portal.transform.position = new Vector3(44, 0.5f, -10);
                portal2.transform.position = new Vector3(-39, 0.5f, -25);
                portalFocus = true;
                CAMeRA.GetComponent<FollowCamera>().lookTarget =portal.transform;
               
                enemyCount++;

            }
        }
        else
        {
            enemyCountUI.GetComponent<Text>().text = enemyCount + "/10";
        }
        if(enemyCount>=10){
            enemyCount = 0;
            ++stage;
            changeStage = true;
            if (stage == 1)
            {
                stageUI.GetComponent<Text>().text = "Stage 1";
                GameObject.Find("EnemyGenerator").GetComponent<EnemyGeneratorCtrl>().setEnemyWarg();
            }
            if (stage==2){
                stageUI.GetComponent<Text>().text = "Stage 2";
                stageUI.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                stageBackground.GetComponent<Image>().color = new Color(0, 1, 0);
                GameObject.Find("EnemyGenerator").GetComponent<EnemyGeneratorCtrl>().setEnemySkeleton();
            }
            if (stage == 3)
            {
                stageUI.GetComponent<Text>().text = "Stage 3";
                stageUI.GetComponent<Text>().color = new Color(1,1,1,1);
                stageBackground.GetComponent<Image>().color = new Color(1, 0, 0);
                 GameObject.Find("EnemyGenerator").GetComponent<EnemyGeneratorCtrl>().setEnemyDragon();
            }
        }
        if(changeStage){
            stageBackground.GetComponent<Image>().enabled = true;
            //stageBackground.GetComponent<Image>().color = new Color(1,1,1,1);
            stageChangeDelta += Time.deltaTime;
            if(stageChangeDelta>3){
                stageChangeDelta = 0;
                stageUI.GetComponent<Text>().text = "";
                changeStage = false;
               stageBackground.GetComponent<Image>().enabled = false;
           //         stageBackground.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }

        }

		
	}
}
