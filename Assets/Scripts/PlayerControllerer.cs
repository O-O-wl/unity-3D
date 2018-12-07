using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[System.Serializable]
public class AnimationController
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;

}*/

public class PlayerControllerer : MonoBehaviour
{
    const float RayCastMaxDistance = 100.0f;
    //public AnimationController animationController;
    //public Animation _animation;
    public Animator animator;
    public GameObject Gunner;
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 100.0f;
    Vector3 moveDir;
    GameObject Cam;
    GameObject x1;
    GameObject x2;
    float reloadTime=0.2f;
    float reloadDelta;

    Vector3 preLoc;
    // Use this for initialization
    void Start()
    {
        reloadDelta = 0;
        Cam = GameObject.Find("Main Camera");
      //  x1 = GameObject.Find("x1");
     //   x2 = GameObject.Find("x2");
        Gunner = GameObject.Find("Gunner");
        animator = Gunner.GetComponent<Animator>();
        tr = transform;
    //    _animation.GetComponentInChildren<Animation>();
    //    _animation.clip = animationController.idle;
   //    _animation.Play();

    }

    // Update is called once per frame
    void Update()
    {
//        Vector3 target = x1.transform.position- x2.transform.position;
       
        if (GetComponent<CharacterStatus>().trans)
        {

            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            moveDir = (Vector3.forward * v) + (Vector3.right * h);
            tr.Translate(moveSpeed * moveDir * Time.deltaTime, Space.Self);
            if(Input.GetKey(KeyCode.E)){
                transform.Rotate(Time.deltaTime * new Vector3(0, 100, 0));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Time.deltaTime * new Vector3(0, -100, 0));
            }
            Vector3 delta_position = transform.position - preLoc;
            animator.SetFloat("Speed", delta_position.magnitude / Time.deltaTime);

            preLoc = transform.position;

            if(Input.GetKey(KeyCode.Space)){
                reloadDelta += Time.deltaTime;
                
                animator.SetBool("Fire", true);
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(509, 230));
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("EnemyHit"))))
                {
                    if (reloadTime < reloadDelta)
                    {
                        reloadDelta = 0;
                        GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().setTarget(hitInfo.point);
                        GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().shoot();
                    }
                }
              //  GameObject.Find("BamsongiGenerator").GetComponent<BamsongiGenerator>().setTarget(transform.rotation.);
              //  GameObject.Find("BamsongiGenerator").GetComponent<BamsongiGenerator>().shoot();
            }
            else{
                animator.SetBool("Fire", false);
                reloadDelta = 0;
            }

            //tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
            // Debug.Log("H=" + h.ToString());
            // Debug.Log("V=" + v.ToString());

            /*  if (v >= 0.1f)
              {
                  _animation.CrossFade(animationController.runForward.name, 0.3f);

              }
              else if (v <= -0.1f)
              {
                  _animation.CrossFade(animationController.runBackward.name, 0.3f);

              }
              else if (h >= 0.1f)
              {
                  _animation.CrossFade(animationController.runRight.name, 0.3f);

              }
              else if (h <= -0.1f)
              {
                  _animation.CrossFade(animationController.runLeft.name, 0.3f);

              }
              else
              {
                  _animation.CrossFade(animationController.idle.name, 0.3f);
              }

      */



           
        }
    }
}
