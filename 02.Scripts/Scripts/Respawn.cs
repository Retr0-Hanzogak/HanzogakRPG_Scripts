using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    /*
    public static Respawn instance;

    //몬스터 생성 
    public Transform[] points;

    public GameObject[] monsterPrefab;

    public float creatTime = 2.0f;

    public int maxMonster = 1;

    //점수 및 스테이지 진행 
    public int score;

    public bool canHit = true;

    public bool isGameOver = false;
    public bool gameEnd = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        PlayerHealth.instance.Reset();

    }
    public void EnemyStart()
    {
        if (points.Length > 0)
        {
            StartCoroutine(CreateMonster());
        }
    }
    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (monsterCount < maxMonster)
            {
                yield return new WaitForSeconds(creatTime);

                int idx = Random.Range(1, points.Length);

                int randomNum = Random.Range(0, monsterPrefab.Length);

                Instantiate(monsterPrefab[randomNum], points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }

    }

    private void Update()
    {
        if (isGameOver)
        {
            UIManager.instance.gameOVer.SetActive(true);

        }
    }
    */
}
