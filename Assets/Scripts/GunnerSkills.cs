using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerSkills : MonoBehaviour {
    /*
    Animator animator;
    float skillTime = 0.1f;
    float skillDelta;
    bool flag;
   
    public float skillCool = 5f; // 쿨 
    public float skillSpan;

    // Use this for initialization
    void Start () {
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
                animator.SetBool("Skill", false);
            }
        }

    }

    public void Skill1(){
        if (skillSpan > 0)
        {
            return;
        }
        skillSpan = skillCool;
        SendMessage("SetDestination", transform.position);
        flag = true;
        animator.SetBool("Skill", true);
        GameObject skill = Instantiate(this.skill) as GameObject;
        skill.transform.position = new Vector3(transform.position.x, 1, transform.position.z);

    }*/
}