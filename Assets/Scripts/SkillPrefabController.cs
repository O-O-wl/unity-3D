using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPrefabController : MonoBehaviour
{
    float biggerTime;
    float endTime = 1.5f;
    // Use this for initialization
    void Start()
    {
        biggerTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        biggerTime += Time.deltaTime;
        transform.localScale = new Vector3(biggerTime * 4, biggerTime * 4, biggerTime * 4);
        if (biggerTime > endTime)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("--");
        if (other.transform.root.tag == "Enemy" | other.transform.root.tag == "Boss")
        {
            Debug.Log("-q");
            other.transform.root.GetComponent<CharacterController>().Move((-transform.position + other.transform.position).normalized * 1.5f); ;
        }
        if (other.gameObject.tag == "fireball")
        {
            Debug.Log("okkkk"); Destroy(other.transform.root.gameObject);
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("okkkk");
        if (collision.transform.root.tag == "fireball")
        {
            Debug.Log("okkk1111k");
            Destroy(collision.transform.root.gameObject);
            //Debug.Log("--");

        }
    }
}
