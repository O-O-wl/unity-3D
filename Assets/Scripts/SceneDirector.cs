using UnityEngine;
using System.Collections;

public class SceneDirector : MonoBehaviour
{
    GameObject player;
    void Start(){
        player = GameObject.Find("Player");
    }
    void Update()
    {
        // 씬 전환은 Application.LoadLevel을 사용한다.
        //if()
        
    }

}
