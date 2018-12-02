using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {
	
	void Damage(AttackArea.AttackInfo attackInfo)
	{
		transform.root.SendMessage ("Damage",attackInfo);
        if(attackInfo.attacker.name=="bamsongi(Clone)"){
            Destroy(attackInfo.attacker.gameObject);
        }
       // if(gameObject.name=="ROOT")
       // GetComponent<MeshRenderer>().material.color = Color.red;


    }
}
