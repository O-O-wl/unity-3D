using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{

    //---------- 공격 장에서 사용한다. ----------
    // 체력.
    public int HP = 100;
    public int MaxHP = 100;
    public bool trans = false;
    public int MaxPower=10;
    // 공격력.
    public int Power = 10;
    public bool haveKey = false;
    // 마지막에 공격한 대상.
    public GameObject lastAttackTarget = null;

    //---------- GUI 및 네트워크 장에서 사용한다. ----------
    // 플레이어 이름.
    public string characterName = "Player";

    //--------- 애니메이션 장에서 사용한다. -----------
    // 상태.
    public bool attacking = false;
    public bool died = false;
 
    public float end=0;
    // 공격력 강화.
    public bool powerBoost = false;
    // 공격력 강화 시간.
    float powerBoostTime = 0.0f;


    // 공격력 강화 효과.
    ParticleSystem powerUpEffect;

    // 아이템 획득.
    public void GetItem(DropItem.ItemKind itemKind)
    {
        switch (itemKind)
        {
            case DropItem.ItemKind.Attack:
                powerBoostTime = 20.0f;
                powerUpEffect.Play();
                break;
            case DropItem.ItemKind.Heal:
                // MaxHP의 절반 회복.
                HP = Mathf.Min(HP + MaxHP / 2, MaxHP);
                break;
            case DropItem.ItemKind.bamsongi:
                GameObject.Find("Main Camera").GetComponent<FollowCamera>().getItem = true;
                break;
            case DropItem.ItemKind.Key:
                haveKey = true;
                break;
        }
    }

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            powerUpEffect = transform.Find("PowerUpEffect").GetComponent<ParticleSystem>();
        }
    }

    void Update()
    {
        Power = Random.Range(MaxPower / 2, MaxPower);

        if (gameObject.tag != "Player")
        {
            return;
        }
        powerBoost = false;
        if (powerBoostTime > 0.0f)
        {
            powerBoost = true;
            Power = Random.Range(25, 50);
        //    transform.localScale=new Vector3(1.3f, 1.3f, 1.3f);
            powerBoostTime = Mathf.Max(powerBoostTime - Time.deltaTime, 0.0f);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            Power = Random.Range(MaxPower / 2, MaxPower);
            powerUpEffect.Stop();
        }
        if((HP<=0&(transform.root.tag=="Player"))|| (HP <= 0 & (transform.root.tag == "Boss"))){
            end += Time.deltaTime;if (end > 1.5)
            {
                Application.LoadLevel("TitleScene");
            }
        }
    }

}
