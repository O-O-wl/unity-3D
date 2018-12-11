using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HitArea : MonoBehaviour {
    public GameObject DamageTextGenerator;
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        DamageTextGenerator = GameObject.Find("DamageTextGenerator");
    }
    void Damage(AttackArea.AttackInfo attackInfo)
	{
        if (transform.root.tag != "Player") { player.GetComponent<CharacterStatus>().lastAttackTarget = transform.root.gameObject; }
		transform.root.SendMessage ("Damage",attackInfo);
        //GameObject damageText = Instantiate(this.DamageText) as GameObject;
        // damageText.GetComponent("TextMeshPro").SendMessage("");

        DamageTextGenerator.SendMessage("setColor", transform.root.name=="Player"?new Color(0.32f,0.11f,0.78f):new Color(1,0,0));

        DamageTextGenerator.SendMessage("set", transform.root.position);
        DamageTextGenerator.SendMessage("create", attackInfo.attackPower);
        if(attackInfo.attacker.name=="bamsongi(Clone)"){
            Destroy(attackInfo.attacker.gameObject);
        }
       // if(gameObject.name=="ROOT")
       // GetComponent<MeshRenderer>().material.color = Color.red;


    }
}
