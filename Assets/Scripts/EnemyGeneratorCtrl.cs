using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyGeneratorCtrl : MonoBehaviour
{
    // 생겨날 적 프리팹.
    public GameObject enemyPrefab;
    public GameObject enemyPrefabSkeleton;
    public GameObject enemyPrefabDragon;
    GameObject stageEnemy;
    float StageDelta;

    // 적을 저장한다. 
    GameObject[] existEnemys;
    // 액티브 최대 수.
    public int maxEnemy = 10;
    bool beginBoss;

    void Start()
    {
        StageDelta = 0;
        stageEnemy = GameObject.Find("StageEnemy");
        beginBoss = true;
        // 배열 확보.
        existEnemys = new GameObject[maxEnemy];
        // 주기적으로 실행하고 싶을 때는 코루틴을 사용하면 쉽게 구현할 수 있다.
        StartCoroutine(Exec());
    }

    // 적을 생성한다.
    IEnumerator Exec()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(3.0f);
        }
    }

    void Generate()
    {
        if (GameObject.Find("UIManager").GetComponent<StageManager>().stage == 3)
        {
            if (beginBoss)
            {
                GameObject dragon = Instantiate(enemyPrefab);
                dragon.transform.position = new Vector3(50, 0, -40);
                beginBoss = false;
            }
        }
        else
        {
            for (int enemyCount = 0; enemyCount < existEnemys.Length; ++enemyCount)
            {
                if (existEnemys[enemyCount] == null)
                {
                    // 적 생성.
                    existEnemys[enemyCount] = Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(0, 20), 0, Random.Range(0, 20)), transform.rotation) as GameObject;
                    return;
                }
            }
        }
    }
    /*
    private void Update()
    {
        StageDelta += Time.deltaTime;
        if(StageDelta>=100){
            enemyPrefab = enemyPrefab3;
        }
        else if (StageDelta >= 50)
        {
            enemyPrefab = enemyPrefab2;
        }
    }
    */
    public void setEnemySkeleton(){
        deleteEnemy();
        enemyPrefab = enemyPrefabSkeleton;
        stageEnemy.GetComponent<Text>().text = "스켈레톤 ";


    }
    
    public void setEnemyDragon() {
        deleteEnemy();
        enemyPrefab = enemyPrefabDragon;
        stageEnemy.GetComponent<Text>().text = "드래곤 ";
    }
    public void setEnemyWarg()
    {
        deleteEnemy();
        stageEnemy.GetComponent<Text>().text = "늑대 ";
    }

    public void deleteEnemy(){
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].gameObject.tag=="Enemy")
                Destroy(GameObjects[i]);
        }
    }
}
