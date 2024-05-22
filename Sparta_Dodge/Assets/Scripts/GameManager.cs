using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public GameObject scoreBoard;

    [SerializeField] private Text hpText;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 1.5f);
            curSpawnDelay = 0;
        }

        hpText.text = "Hp " + player.GetComponent<Player>().life.ToString();
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 9);

        GameObject enemy= Instantiate(enemyObjs[ranEnemy],
                          spawnPoints[ranPoint].position,
                          Quaternion.Euler(0, 0, -90));

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        EnemySpawn enemyLogic = enemy.GetComponent<EnemySpawn>();
        enemyLogic.player = player;

        if (ranPoint == 5 || ranPoint == 6)
        {
            rigid.velocity = new Vector2(enemyLogic.speed * -1, 1);
        }
        else if (ranPoint == 7 || ranPoint == 8)
        {
            rigid.velocity = new Vector2(enemyLogic.speed * -1, -1);
        }
        else
        {
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), 0);
        }
        
              
        
    }

    public void GameOver()
    {
        scoreBoard.SetActive(true);
    }
}
