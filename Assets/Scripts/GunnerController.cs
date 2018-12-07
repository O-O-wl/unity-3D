using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerController : MonoBehaviour {
    InputManager inputManager;
    GameObject Gunner;
    Animator animator;
    float reloadTime=1f;
    float reloadDelta;

    const float RayCastMaxDistance = 100.0f;
    // Use this for initialization
    void Start () {
        Gunner = GameObject.Find("Gunner");
        animator = Gunner.GetComponent<Animator>();
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
	}

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CharacterStatus>().trans)
        {
            if(Input.GetKey(KeyCode.R)){
                if (inputManager.Clicked())
                {
                    animator.SetBool("Fire", true);
                    Vector2 point = inputManager.GetCursorPosition();

                        Ray ray = Camera.main.ScreenPointToRay(point);

                        Debug.Log(inputManager.GetCursorPosition());
                        RaycastHit hitInfo;
                        if (Physics.Raycast(ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("EnemyHit"))))
                        {

                            GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().setTarget(hitInfo.point);
                            GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().shoot();
                        }
                    return;

                }
            }

            if (Input.GetMouseButton(0))
            {
               
                Vector2 point = inputManager.GetCursorPosition();
                if (point.y > 200)
                {
                    animator.SetBool("Fire", true);
                    Ray ray = Camera.main.ScreenPointToRay(point);

                    Debug.Log(inputManager.GetCursorPosition());
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("EnemyHit"))))
                    {

                        GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().setTarget(hitInfo.point);
                        GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().shoot();
                    }
                }
            }




        }

    }
}
