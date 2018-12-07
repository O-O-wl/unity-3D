using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillGUIController : MonoBehaviour {

    public GameObject skill1UI;
    public GameObject skill2UI;
    public GameObject player;
    

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(player.GetComponent<CharacterStatus>().trans){
            skill1UI.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            skill1UI.GetComponent<Button>().enabled = false;
            skill2UI.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            skill2UI.GetComponent<Button>().enabled = false;

        }
        else{
            skill2UI.GetComponent<Image>().color = new Color(1, 1, 1);
            skill2UI.GetComponent<Button>().enabled = true;
            skill1UI.GetComponent<Image>().color = new Color(1,1,1);
            skill1UI.GetComponent<Button>().enabled = true;
        }
        skill1UI.GetComponent<Image>().fillAmount
                = player.GetComponent<SkillController>().skillSpan == 0 ? 1 :1-( player.GetComponent<SkillController>().skillSpan / 5);

        skill2UI.GetComponent<Image>().fillAmount
              = player.GetComponent<SkillController2>().skillSpan == 0 ? 1 : 1 - (player.GetComponent<SkillController2>().skillSpan / 7);

    }
}
