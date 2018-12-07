using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController2 : MonoBehaviour {
    Animator animator;
    float skillTime = 0.1f;
    float skillDelta;
    bool flag;
    public GameObject skill;
    public float skillCool = 7f; // 쿨 
    public float skillSpan;

    // Use this for initialization
    void Start () {
        //GameObject.Find("MainCamera").GetComponent<FollowCamera>().lookTarget = gameObject.transform.p;
        skillDelta = 0;
        skillSpan = 0; //남은 쿨
        animator = GetComponent<Animator>();
        flag = false;
    }
    
    // Update is called once per frame
    void Update () {
        if(skillSpan>0){
            skillSpan -= Time.deltaTime;
        }
        else if(skillSpan<0){
            skillSpan = 0;
        }
        if(flag){
            skillDelta += Time.deltaTime;
            if(skillTime<skillDelta){
                flag = false;
                animator.SetBool("Skill2", false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if (!GameObject.Find("Player").GetComponent<CharacterStatus>().trans)
                Skill2();
        }
    }
    public void Skill2(){
        if (skillSpan > 0)
        {
            return;
        }
        skillSpan = skillCool;
        SendMessage("SetDestination", transform.position);
        flag = true;
        animator.SetBool("Skill2", true);
        for (int i = 0; i < 5; i++)
        {
            GameObject skill = Instantiate(this.skill) as GameObject;
            skill.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }
}

