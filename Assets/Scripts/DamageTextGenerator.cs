using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageTextGenerator : MonoBehaviour
{
    public GameObject DamageText;

    Vector3 temp;
    Color color;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void create(int power)
    {
        GameObject DamageText = Instantiate(this.DamageText) as GameObject;
        DamageText.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
        DamageText.GetComponent<TextMesh>().text = power.ToString();
        DamageText.GetComponent<TextMesh>().color = this.color;
        if(power>=20){
            DamageText.GetComponent<TextMesh>().color = Color.yellow;
            DamageText.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        DamageText.transform.position = temp;
    }
    public void set(Vector3 loc){
        temp = loc;
    }
    public void setColor(Color color){
        this.color = color;
    }
}
